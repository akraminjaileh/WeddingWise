using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IClientServices
    {
        //Reservation Assist
        Task<int> OpenNewReservation(int userId);
        Task UpdateReservationPrice(int reservationId);
        Task RefreshReservationStatus();

        //Reservation Action

        Task<IEnumerable<ReservationRecordDTO>> GetReservationHistory(JwtPayload payload);
        Task<ReservationDetailsDTO> GetReservationDetails(int reservationId, JwtPayload payload);
        Task<int> AddCarInReservation (ReservationCarDTO dto, JwtPayload payload);
        Task<int> AddWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto, JwtPayload payload);
        Task<int> RemoveCarFromReservation(int reservationId, int reservationCarId, JwtPayload payload);
        Task<int> RemoveWeddingRoomFromReservation(int reservationId, int reservationWeddingId, JwtPayload payload);
        Task<int> Checkout(JwtPayload payload);

    }
}
