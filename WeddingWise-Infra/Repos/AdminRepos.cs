using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.IDbRepos;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Repos
{
    public class AdminRepos : IAdminRepos
    {
        private readonly WeddingWiseDbContext context;
        private readonly IDbRepos dbRepos;

        public AdminRepos(WeddingWiseDbContext context) => this.context = context;





        #region Get Agent Id for Create Car or Wedding

        public async Task<int> GetAgentId(int AgentId)
        {
            var agent = await context.Users.FindAsync(AgentId);
            if (agent == null)
            {
                throw new KeyNotFoundException($"Agent with ID {AgentId} not found.");
            }

            return agent.Id;
        }

        #endregion


        #region CarRental Management

        public async Task<CarRental> UpdateCar(int id)
        {
            var car = await context.CarRentals.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }

            return car;
        }



        public async Task<CarRental> DeleteCar(int id)
        {

            var car = await context.CarRentals.FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }

            return car;
        }

        #endregion


        #region WeddingHall Management


        public async Task<WeddingHall> UpdateWeddingHall(int id)
        {
            var wedding = await context.WeddingHalls.FirstOrDefaultAsync(x => x.Id == id);
            if (wedding == null)
            {
                throw new KeyNotFoundException($"Wedding with ID {id} not found.");
            }

            return wedding;
        }

        public async Task<WeddingHall> DeleteWeddingHall(int id)
        {
            var wedding = await context.WeddingHalls.FirstOrDefaultAsync(x => x.Id == id);

            if (wedding == null)
            {
                throw new KeyNotFoundException($"Wedding with ID {id} not found.");
            }

            return wedding;
        }

        #endregion


        #region Room Management


        public async Task<Room> UpdateRoom(int id)
        {
            var room = await context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (room == null)
            {
                throw new KeyNotFoundException($"Room with ID {id} not found.");
            }

            return room;
        }

        public async Task<Room> DeleteRoom(int id)
        {
            var room = await context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (room == null)
            {
                throw new KeyNotFoundException($"Room with ID {id} not found.");
            }

            return room;
        }

        #endregion

    }

}
