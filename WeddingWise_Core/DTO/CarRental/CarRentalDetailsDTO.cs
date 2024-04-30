using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.User;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.CarRental
{
    public class CarRentalDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Modal { get; set; }
        public DateTime Year { get; set; }
        public string LicensePlate { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public float PricePerHour { get; set; }
        public Status Status { get; set; }
        public virtual UserRecordDTO User { get; set; }
        public virtual UserRecordDTO Agent { get; set; }
        public virtual List<ReservationCarRecordDTO> ReservationCars { get; set; } = new List<ReservationCarRecordDTO>();

        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
