using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class Reservation:ParentEntity
    {
        public Status Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PromoCode { get; set; }
        public float NetPrice { get; set; }
        public float TaxAmount { get; set; }
        public float DiscountAmount { get; set; }
        public float TotalPrice { get; set; }
        public virtual List<ReservationCar> ReservationCars {  get; set; }
        public virtual List<ReservationWeddingHall>  ReservationWeddingHalls {  get; set; }
        public virtual User User { get; set; }

    }
}
