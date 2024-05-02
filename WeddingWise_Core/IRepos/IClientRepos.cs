using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IClientRepos
    {
        Task<User> OpenNewReservation(int id);
        Task<int> SaveChangesAsync();
        void AddToDb(object obj);
        void UpdateOnDb(object obj);
        Task<Reservation> GetReservationById(int id);
        Task<CarRental> AddOrUpdateCarInReservation(int id);
        Task<Room> AddOrUpdateWeddingRoomInReservation(int id);
        Task<Reservation> UpdateReservationPrice(int reservationId);
        Task<bool> IsCarAvailable(int carId, DateTime startTime, DateTime endTime);
        Task<bool> IsRoomAvailable(int roomId, DateTime startTime, DateTime endTime);

    }
}
