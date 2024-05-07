using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.ReservationWeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IClientServices
    {
        //Reservation Assist
        Task<int> OpenNewReservation(int id);
        Task UpdateReservationPrice(int reservationId);

        //Reservation Action

        Task<IEnumerable<ReservationRecordDTO>> GetReservationHistory(JwtPayload token);
        Task<ReservationDetailsDTO> GetReservationDetails(int id, JwtPayload token);
        Task<int> AddCarInReservation
           (DateTime StartTime, DateTime EndTime, int CarRentalId, JwtPayload claim);
        Task<int> AddWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto, JwtPayload claim);
        Task<int> RemoveCarFromReservation(int reservationId, int reservationCarId, JwtPayload claim);
        Task<int> RemoveWeddingRoomFromReservation(int reservationId, int reservationWeddingId, JwtPayload claim);
        Task<int> Checkout(int id, JwtPayload token);

    }
}
