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

        public async Task<User> GetUserById(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }

            return user;
        }

        public async Task<User> Login(LoginDTO dto)
        {
            var user = await context.Users.FirstOrDefaultAsync(u =>

                u.Email == dto.UserName && u.Password == dto.Password
            );
            if (user == null)
            {
                throw new KeyNotFoundException("UserName or Password Incorrect ");
            }
            return user;
        }


        #endregion

    }
}
