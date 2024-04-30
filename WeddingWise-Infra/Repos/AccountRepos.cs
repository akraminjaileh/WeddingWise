using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.DTO.Account;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Repos
{
    public class AccountRepos : IAccountRepos
    {
        private readonly WeddingWiseDbContext context;

        public AccountRepos(WeddingWiseDbContext context) => this.context = context;



        #region User Management
        public async Task<int> Registration(RegistrationDTO dto, bool IsAdminOrEmployee)
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

                if (IsAdminOrEmployee)
                {
                    user.NationalNo = dto.NationalNo;
                    user.UserType = dto.UserType;
                }

                context.Users.Add(user);

                int affectedRows = await context.SaveChangesAsync();
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



        public async Task<int> UpdateProfile(UpdateProfileDTO dto, int id, bool IsAdmin)
        {
            try
            {
                var user = await context.Users.FindAsync(id);

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

                if (IsAdmin)
                {
                    user.Email = dto.Email ?? user.Email;
                    user.NationalNo = dto.NationalNo ?? user.NationalNo;
                    user.UserType = dto.UserType ?? user.UserType;
                    user.IsActive = dto.IsActive ?? user.IsActive;
                }

                context.Update(user);
                int affectedRows = await context.SaveChangesAsync();
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



        public async Task<int> DisableAccount(int id)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    user.IsActive = false;
                    context.Update(user);
                    var affectedRows = await context.SaveChangesAsync();
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
