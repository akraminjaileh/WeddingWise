using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Repos
{
    public class GetRepos : IGetRepos
    {
        private readonly WeddingWiseDbContext context;

        public GetRepos(WeddingWiseDbContext context) => this.context = context;


        #region Get User
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await context.Users.ToListAsync();

        }

        public async Task<User> GetOneUserDetails(int id)
        {

            var user = await context.Users
                .Include(u => u.AgentTransactions)
                .Include(u => u.Reservations)
                .Include(u => u.Reservations).ThenInclude(x => x.ReservationCars).ThenInclude(x => x.CarRental)
                .Include(u => u.Reservations).ThenInclude(x => x.ReservationWeddingHalls).ThenInclude(x => x.WeddingHall)

                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new ApplicationException($"The User with Id : {id} not found");
            }
            return user;

        }

        #endregion


        #region Get Car

        public async Task<IEnumerable<CarRental>> GetAllCar()
        {
            return await context.CarRentals.ToListAsync();

        }

        public async Task<CarRental> GetCarsDetails(int id)
        {
            var cars = await context.CarRentals
                .Include(c => c.User)
                .Include(r => r.ReservationCars)
                .Include(a => a.Agent)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cars == null)
            {
                throw new KeyNotFoundException("Car with the specified ID not found.");
            }
            return cars;

        }

        #endregion


        #region Get Wedding Hall
        public async Task<IEnumerable<WeddingHall>> GetAllWedding()
        {
            return await context.WeddingHalls.ToListAsync();

        }

        public async Task<WeddingHall> GetWeddingDetails(int id)
        {
            var wedding = await context.WeddingHalls
               .Include(c => c.User)
               .Include(r => r.ReservationWeddingHalls)
               .Include(a => a.Agent)
               .Include(b => b.Rooms)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (wedding == null)
            {
                throw new KeyNotFoundException($"Wedding with the specified ID : {id} not found.");
            }
            return wedding;

        }
        #endregion


        #region Get Room 
        public async Task<Room> GetRoomDetails(int id)
        {
            var room = await context.Rooms
               .FirstOrDefaultAsync(c => c.Id == id);

            if (room == null)
            {
                throw new KeyNotFoundException($"Room with the specified ID : {id} not found.");
            }
            return room;

        }
        #endregion


    }

}

