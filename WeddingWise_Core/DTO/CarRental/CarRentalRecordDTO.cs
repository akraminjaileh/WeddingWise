using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.CarRental
{
    public class CarRentalRecordDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public City City { get; set; }
        public float PricePerHour { get; set; }
        public Status Status { get; set; }
    }
}
