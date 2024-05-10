using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Repos
{
    public class AdminRepos : IAdminRepos
    {
        private readonly WeddingWiseDbContext context;

        public AdminRepos(WeddingWiseDbContext context) => this.context = context;





        #region Get Agent Id for Create Car or Wedding

        public async Task<User> GetUserId(int Id)
        {
            var user = await context.Users.FindAsync(Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {Id} not found.");
            }

            return user;
        }

        #endregion


        #region CarRental Management

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
