using WeddingWise_Core.Models.Shared;

namespace WeddingWise_Core.Models.Entities
{
    public class ReservationCar : ParentEntity
    {

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual CarRental CarRental { get; set; }
    }
}
