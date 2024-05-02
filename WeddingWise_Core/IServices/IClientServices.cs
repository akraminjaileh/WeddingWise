using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.DTO.ReservationWeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IClientServices
    {
        //Open Reservation Container
        Task<int> OpenNewReservation(int id);
        // Task CloseReservation();
        Task<int> AddOrUpdateCarInReservation
            (DateTime StartTime, DateTime EndTime, int CarRentalId, int ClientId);
        Task<int> AddOrUpdateWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto);
           
        Task UpdateReservationPrice(int reservationId);

    }
}
