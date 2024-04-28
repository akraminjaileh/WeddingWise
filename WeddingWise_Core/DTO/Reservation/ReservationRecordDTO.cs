using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.Reservation
{
    public class ReservationRecordDTO
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public float TotalPrice { get; set; }
    }
}
