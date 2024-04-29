using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.WeddingHall;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.User
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Image { get; set; }
        public string NationalNo { get; set; }
        public UserType UserType { get; set; }
        public virtual List<AgentTransactionRecordDTO> AgentTransactions { get; set; } = new List<AgentTransactionRecordDTO>();
        public virtual List<ReservationRecordDTO> Reservations { get; set; } = new List<ReservationRecordDTO>();
        public virtual List<CarRentalRecordDTO> CarRentals { get; set; } = new List<CarRentalRecordDTO>();
        public virtual List<WeddingHallRecordDTO> WeddingHalls { get; set; } = new List<WeddingHallRecordDTO>();
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }

    }
}
