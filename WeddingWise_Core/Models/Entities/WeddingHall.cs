using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class WeddingHall : ParentEntity
    {

        public string Title { get; set; }
        public string Image { get; set; }
        public string Review { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public virtual List<Room> Rooms { get; set; }
        public virtual List<ReservationWeddingHall> ReservationWeddingHalls { get; set; }
        public virtual User User { get; set; }
        public virtual User Agent { get; set; }
    }
}
