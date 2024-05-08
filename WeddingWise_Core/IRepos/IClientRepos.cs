using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IClientRepos
    {
        //Reservation Assist
        Task<User> OpenNewReservation(int userId);
        Task<Reservation> GetReservationById(int id);
        Task<bool> IsCarAvailable(int carId, DateTime startTime, DateTime endTime);
        Task<bool> IsRoomAvailable(int roomId, DateTime startTime, DateTime endTime);
        IEnumerable<Reservation> GetPendingReservation();


        //Reservation Action
        Task<IEnumerable<Reservation>> GetReservationHistory(int UserId);
        Task<Reservation> GetReservationDetails(int reservationId, int userId);
        Task<CarRental> AddCarInReservation(int id);
        Task<Room> AddWeddingRoomInReservation(int id);
        Task<ReservationCar> RemoveCarFromReservation(int reservationCarId, int reservationId);
        Task<ReservationWeddingHall> RemoveWeddingRoomFromReservation(int reservationWeddingId, int reservationId);
  

    }
}
