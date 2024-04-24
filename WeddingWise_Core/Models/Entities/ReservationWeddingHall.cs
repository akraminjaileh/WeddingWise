﻿using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class ReservationWeddingHall : ParentEntity
    {

        public int GuestCount { get; set; }
        public DateTime DayTime { get; set; }
        public SweetType SweetType { get; set; }
        public BeverageType BeverageType { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }
    }
}
