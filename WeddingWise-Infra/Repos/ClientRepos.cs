using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Repos
{
    public class ClientRepos : IClientRepos
    {
        private readonly WeddingWiseDbContext context;

        public ClientRepos(WeddingWiseDbContext context) => this.context = context;


        #region Effected on databases

        public void AddToDb(object obj)
        {
            context.Add(obj);
        }
        public void UpdateOnDb(object obj)
        {
            context.Update(obj);
        }
        public void DeleteFromDb(object obj)
        {
            context.Remove(obj);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        #endregion


        #region Reservation Assist 

        public async Task<Reservation> GetReservationById(int id)
        {
            var reservation = await context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (reservation == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");
            }
            return reservation;
        }

        public async Task<User> OpenNewReservation(int id)
        {
            var client = await context.Users
                .Include(r => r.Reservations).FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                throw new KeyNotFoundException($"Client with ID {id} not found.");
            }
            return client;

        }


        public async Task<bool> IsCarAvailable(int carId, DateTime startTime, DateTime endTime)
        {
            bool isUnavailable = await context.ReservationCars.AnyAsync(r =>
                r.CarRental.Id == carId &&
                r.Reservation.Status.HasFlag(Status.Confirmed) &&
                ((r.StartTime <= endTime && r.StartTime >= startTime) ||
                 (r.EndTime >= startTime && r.EndTime <= endTime) ||
                 (r.StartTime <= startTime && r.EndTime >= endTime))
                 );

            return !isUnavailable;
        }


        public async Task<bool> IsRoomAvailable(int roomId, DateTime startTime, DateTime endTime)
        {
            bool isUnavailable = await context.ReservationWeddingHalls.AnyAsync(r =>
                r.Room.Id == roomId &&
                r.Reservation.Status.HasFlag(Status.Confirmed) &&
                ((r.StartTime <= endTime && r.StartTime >= startTime) ||
                 (r.EndTime >= startTime && r.EndTime <= endTime) ||
                 (r.StartTime <= startTime && r.EndTime >= endTime))
                 );

            return !isUnavailable;
        }

        public async Task<Reservation> UpdateReservationPrice(int reservationId)
        {
            var reservationCarOrWedding = await context.Reservations.FindAsync(reservationId);
            if (reservationCarOrWedding == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {reservationCarOrWedding} not found.");
            }
            return reservationCarOrWedding;

        }

        #endregion


        #region Reservation Action

        public async Task<CarRental> AddCarInReservation(int id)
        {
            var car = await context.CarRentals
                .Include(x => x.ReservationCars)
                .ThenInclude(r => r.Reservation)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
            return car;
        }

        public async Task<Room> AddWeddingRoomInReservation(int id)
        {
            var room = await context.Rooms
                .Include(m => m.WeddingHall)
                .Include(x => x.ReservationWeddingHalls)
                .ThenInclude(r => r.Reservation)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (room == null)
            {
                throw new KeyNotFoundException($"Wedding with ID {id} not found.");
            }
            return room;
        }

        public async Task<ReservationCar> RemoveCarFromReservation(int id)
        {
            var reservationCars = await context.ReservationCars.FirstOrDefaultAsync(x => x.Id == id);
            if (reservationCars == null)
            {
                throw new KeyNotFoundException($"ReservationCars with ID {id} not found.");
            }

            return reservationCars;
        }

        public async Task<ReservationWeddingHall> RemoveWeddingRoomFromReservation(int id)
        {
            var reservationWedding = await context.ReservationWeddingHalls.FirstOrDefaultAsync(x => x.Id == id);
            if (reservationWedding == null)
            {
                throw new KeyNotFoundException($"ReservationWedding with ID {id} not found.");
            }

            return reservationWedding;
        }

        public async Task<IEnumerable<Reservation>> GetReservationHistory(int UserId)
        {
            return await context.Reservations.Where(x=>x.User.Id == UserId).ToListAsync();

        }

        public async Task<Reservation> GetReservationDetails(int id)
        {
            var reservation = await context.Reservations
                .Include(x => x.ReservationCars).ThenInclude(x => x.CarRental)
                .Include(x => x.ReservationWeddingHalls).ThenInclude(x => x.WeddingHall)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (reservation == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");
            }

            return reservation;
        }

        public async Task<Reservation> Checkout(int id)
        {
            var reservation = await context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (reservation == null)
            {
                throw new KeyNotFoundException($"Reservation with ID {id} not found.");
            }

            return reservation;
        }

        #endregion


    }
}
