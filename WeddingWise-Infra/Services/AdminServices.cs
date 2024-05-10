﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IDbRepos;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepos repos;
        private readonly IDbRepos dbRepos;

        public AdminServices(IAdminRepos repos , IDbRepos dbRepos)
        {
            this.repos = repos;
            this.dbRepos = dbRepos;
        }


        #region CarRental Management

        public async Task<int> CreateCar(CreateOrUpdateCarDTO dto, JwtPayload token)
        {
            try
            {
                if (!token.Claims.Any())
                {
                    throw new KeyNotFoundException("Invalid Token Claims");
                }

                int userId = int.Parse(token.ElementAt(0).Value.ToString());

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Admin.ToString()) || !userType.Equals(UserType.Employee.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var car = new CarRental
                {
                    Title = dto.Title,
                    Image = dto.Image,
                    Brand = dto.Brand,
                    Color = dto.Color,
                    Modal = dto.Modal,
                    Year = dto.Year.Value,
                    LicensePlate = dto.LicensePlate,
                    City = dto.City.Value,
                    Address = dto.Address,
                    PricePerHour = dto.PricePerHour.Value,

                };

                car.User.Id = userId;

                if (dto.AgentId <= 0)
                {
                    throw new KeyNotFoundException($"Agent with ID {dto.AgentId} not found.");
                }

                int agent = await repos.GetAgentId(dto.AgentId);
                car.Agent.Id = agent;

                dbRepos.AddToDb(car);

                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }

            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to create car rental due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating car rental.", ex);
            }
        }



        public async Task<int> DeleteCar(int id, string token)
        {
            try
            {
                if (token.Equals(UserType.Client.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }
                var car = await repos.DeleteCar(id);

                car.IsActive = false;
                dbRepos.UpdateOnDb(car);
                var affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


        #region WeddingHall Management
        public async Task<int> CreateWeddingHall(CreateOrUpdateWeddingHallDTO dto, JwtPayload token)
        {
            try
            {

                if (!token.Claims.Any())
                {
                    throw new KeyNotFoundException($"Invalid Token Claims");
                }
                int agentId = await repos.GetAgentId(dto.AgentId);
                int userId = int.Parse(token.ElementAt(0).Value.ToString());

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Admin.ToString()) || !userType.Equals(UserType.Employee.ToString()))
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }
                var wedding = new WeddingHall
                {
                    Title = dto.Title,
                    City = dto.City.Value,
                    Address = dto.Address,
                };

                wedding.User.Id = userId;

                if (dto.AgentId <= 0)
                {
                    throw new KeyNotFoundException($"Agent with ID {dto.AgentId} not found.");
                }
                wedding.Agent.Id = agentId;

                dbRepos.AddToDb(wedding);
                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to create wedding due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating wedding.", ex);
            }
        }

        

        public async Task<int> DeleteWeddingHall(int id, string token)
        {
            try
            {
                if (token.Equals(UserType.Client.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");
                }

                var wedding = await repos.DeleteWeddingHall(id);

                wedding.IsActive = false;
                dbRepos.UpdateOnDb(wedding);
                var affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;


            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


        #region Room Management
        public async Task<int> CreateRoom(CreateOrUpdateRoom dto, JwtPayload token)
        {
            try
            {
                if (!token.Claims.Any())
                {
                    throw new KeyNotFoundException($"Invalid Token Claims");
                }

                int userId = int.Parse(token.ElementAt(0).Value.ToString());

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Admin.ToString()) || !userType.Equals(UserType.Employee.ToString()))
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }
                var room = new Room
                {
                    RoomName = dto.RoomName,
                    SeatsNumber = dto.SeatsNumber,
                    Floor = dto.Floor,
                    StartPrice = dto.StartPrice.Value,
                };
                room.WeddingHall.Id = dto.WeddingHallId;


                dbRepos.AddToDb(room);
                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to create Room due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating Room.", ex);
            }
        }

       

        public async Task<int> DeleteRoom(int id, string token)
        {
            try
            {
                if (token.Equals(UserType.Client.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");
                }

                var room = await repos.DeleteRoom(id);

                room.IsActive = false;
                dbRepos.UpdateOnDb(room);
                var affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


    }
}
