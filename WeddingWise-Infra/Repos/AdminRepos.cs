using Microsoft.IdentityModel.Tokens;
using WeddingWise_Core.Context;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Repos
{
    public class AdminRepos : IAdminRepos
    {
        private readonly WeddingWiseDbContext context;

        public AdminRepos(WeddingWiseDbContext context) => this.context = context;


        public async Task<int> CreateUser(CreateOrUpdateUserDTO dto)
        {
            
            var userDto = new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                Birthday = dto.Birthday.Value,
                City = dto.City.Value,
                Email = dto.Email,
                NationalNo = dto.NationalNo,
                Phone = dto.Phone,
                UserType = dto.UserType.Value
            };

            if (userDto != null)
            {
                context.Users.Add(userDto);
            }

            int affectedRows = await context.SaveChangesAsync();
            return affectedRows;
        }


        public async Task<int> UpdateUser(CreateOrUpdateUserDTO dto, int id, bool IsAdmin)
        {
            var user =await  context.Users.FindAsync(id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {dto.Id} not found.");
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
            int affectedRows =  context.SaveChanges();
            return affectedRows;
        }


        public Task<int> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }

}
