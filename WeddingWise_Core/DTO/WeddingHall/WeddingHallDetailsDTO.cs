using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.WeddingHall
{
    public class WeddingHallDetailsDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Image { get; set; }
        public string Review { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public virtual List<RoomRecordDTO> Rooms { get; set; }
        public virtual List<ReservationWeddingHallRecordDTO> ReservationWeddingHalls { get; set; }
        public virtual UserRecordDTO User { get; set; }
        public virtual UserRecordDTO Agent { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
