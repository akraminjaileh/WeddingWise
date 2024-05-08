namespace WeddingWise_Core.Models.Entities
{
    public class ReservationCar
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual CarRental CarRental { get; set; }
        public bool IsCompleted { get; set; }
    }
}
