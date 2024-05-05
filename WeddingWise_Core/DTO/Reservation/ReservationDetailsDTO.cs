using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.Reservation
{
    public class ReservationDetailsDTO
    {
        public Status Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PromoCode { get; set; }
        public float NetPrice { get; set; }
        public float TaxAmount { get; set; }
        public float DiscountAmount { get; set; }
        public float TotalPrice { get; set; }
        public virtual List<ReservationCarRecordDTO> ReservationCars { get; set; }
        public virtual List<ReservationWeddingHallRecordDTO> ReservationWeddingHalls { get; set; }
    }
}
