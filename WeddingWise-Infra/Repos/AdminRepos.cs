using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IRepos;

namespace WeddingWise_Infra.Repos
{
    public class AdminRepos : IAdminRepos
    {
        private readonly WeddingWiseDbContext context;

        public AdminRepos(WeddingWiseDbContext context) => this.context = context;


        public async Task CreateUser(CreateUserDTO user)
        {
            throw new NotImplementedException();

        }


        public Task UpdateUser(UpdateUserDTO user)
        {
            throw new NotImplementedException();
        }


        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }

}
