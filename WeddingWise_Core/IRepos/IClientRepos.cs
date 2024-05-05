using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IClientRepos
    {
        //Reservation Assist
        Task<User> OpenNewReservation(int id);
        Task<Reservation> UpdateReservationPrice(int reservationId);
        Task<bool> IsCarAvailable(int carId, DateTime startTime, DateTime endTime);
        Task<bool> IsRoomAvailable(int roomId, DateTime startTime, DateTime endTime);

        //DataBase Modify
        Task<int> SaveChangesAsync();
        void AddToDb(object obj);
        void UpdateOnDb(object obj);
        void DeleteFromDb(object obj);

        //Reservation Action
        Task<IEnumerable<Reservation>> GetReservationHistory(int UserId);
        Task<Reservation> GetReservationDetails(int id);
        Task<CarRental> AddCarInReservation(int id);
        Task<Room> AddWeddingRoomInReservation(int id);
        Task<ReservationCar> RemoveCarFromReservation(int id);
        Task<ReservationWeddingHall> RemoveWeddingRoomFromReservation(int id);
        Task<Reservation> Checkout(int id);

    }
}
