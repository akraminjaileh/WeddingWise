using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class User : ParentEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Image { get; set; }
        public string NationalNo { get; set; }
        public UserType UserType { get; set; }
        public virtual List<AgentTransaction> AgentTransactions { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        public virtual List<CarRental> CarRentals { get; set; }
        public virtual List<WeddingHall> WeddingHalls { get; set; }

    }
}
