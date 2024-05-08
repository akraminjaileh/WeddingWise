using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class ReservationWeddingHall
    {
        public int Id { get; set; }
        public int GuestCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public SweetType SweetType { get; set; }
        public BeverageType BeverageType { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }
        public virtual Room Room { get; set; }
        public bool IsCompleted { get; set; }
    }
}
