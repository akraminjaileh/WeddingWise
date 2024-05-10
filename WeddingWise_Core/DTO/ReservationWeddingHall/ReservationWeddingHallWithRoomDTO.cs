using WeddingWise_Core.DTO.Room;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.ReservationWeddingHall
{
    public class ReservationWeddingHallWithRoomDTO
    {
        public int GuestCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public SweetType SweetType { get; set; }
        public BeverageType BeverageType { get; set; }
        public  int WeddingHallId { get; set; }
        public int RoomId { get; set; }
    }
}
