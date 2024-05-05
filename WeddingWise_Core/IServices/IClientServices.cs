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
           (DateTime StartTime, DateTime EndTime, int CarRentalId, int ClientId, string token);
        Task<int> AddWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto, string token);
        Task<int> RemoveCarFromReservation(int id, string token);
        Task<int> RemoveWeddingRoomFromReservation(int id, string token);
        Task<int> Checkout(int id, JwtPayload token);

    }
}
