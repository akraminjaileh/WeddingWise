﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeddingWise_Core.DTO.Account;
using WeddingWise_Core.IDbRepos;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using WeddingWise_Infra.DbRepos;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepos repos;
        private readonly IConfiguration configuration;
        private readonly IDbRepos dbRepos;

        public AccountServices(IAccountRepos repos, IConfiguration configuration , IDbRepos dbRepos)
        {
            this.repos = repos;
            this.configuration = configuration;
            this.dbRepos = dbRepos;
        }


        #region User Management

        public async Task<int> Registration(RegistrationDTO dto)
        {
            try
            {
                var user = new User
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Birthday = dto.Birthday,
                    City = dto.City,
                    Email = dto.Email,
                    Password = dto.Password,
                    Phone = dto.Phone
                };

                user.UserType = UserType.Client;
                user.CreationDateTime = DateTime.Now;
                dbRepos.AddToDb(user);

                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to create a new user due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating a new user.", ex);
            }

        }


        public async Task<string> Login(LoginDTO dto)
        {
            try
            {
                var user = await repos.Login(dto);

                //Generate Token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(configuration["Security:TokenKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId",user.Id.ToString()),
                        new Claim("UserType",user.UserType.GetDisplayName())
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                    , SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }


        public async Task<int> UpdateProfile(UpdateProfileDTO dto, JwtPayload payload, int id)
        {

            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }
                int userId;

                if (!int.TryParse(payload["UserId"].ToString(), out userId))
                    throw new UnauthorizedAccessException("Invalid Token Claims");

                var userType = payload["UserType"].ToString();

                if (userType.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var user = await repos.GetUserById(userId);

                if (userType.Equals(UserType.Admin.ToString()))
                {
                    user = await repos.GetUserById(id);
                }
                if (user == null)
                {
                    throw new KeyNotFoundException($"User with ID {id} not found.");
                }

                user.Name = dto.Name ?? user.Name;
                user.Address = dto.Address ?? user.Address;
                user.Birthday = dto.Birthday ?? user.Birthday;
                user.City = dto.City ?? user.City;
                user.Phone = dto.Phone ?? user.Phone;
                user.Image = dto.Image ?? user.Image;

                if (userType.Equals(UserType.Admin))
                {
                    user.Email = dto.Email ?? user.Email;
                    user.NationalNo = dto.NationalNo ?? user.NationalNo;
                    user.UserType = dto.UserType ?? user.UserType;
                    user.IsActive = dto.IsActive ?? user.IsActive;
                }

                dbRepos.UpdateOnDb(user);
                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to update user due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating user.", ex);
            }
        }


        public async Task<int> DisableAccount(int id, JwtPayload payload)
        {

            try
            {

                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }
            
                var userType = payload["UserType"].ToString();

                if (!userType.Equals(UserType.Admin.ToString()) || userType.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var user = await repos.GetUserById(id);
                if (user != null)
                {
                    user.IsActive = false;
                    dbRepos.UpdateOnDb(user);
                    var affectedRows = await dbRepos.SaveChangesAsync();
                    return affectedRows;
                }

                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }



        #endregion





    }
}
