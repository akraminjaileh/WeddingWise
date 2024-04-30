using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class CarRental : ParentEntity
    {

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
        public virtual User User { get; set; }
        public virtual User Agent { get; set; }
        public virtual List<ReservationCar> ReservationCars { get; set; }
    }
}
