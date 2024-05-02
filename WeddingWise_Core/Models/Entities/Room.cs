using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class Room : ParentEntity
    {

        public string RoomName { get; set; }
        public string Image { get; set; }
        public int SeatsNumber { get; set; }
        public string Floor { get; set; }
        public string Description { get; set; }
        public float StartPrice { get; set; }
        public Status Status { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }
        public virtual List<ReservationWeddingHall> ReservationWeddingHalls { get; set; }

    }
}
