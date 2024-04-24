﻿using WeddingWise_Core.Models.Shared;

namespace WeddingWise_Core.Models.Entities
{
    public class Room : ParentEntity
    {

        public string RoomName { get; set; }
        public string Image { get; set; }
        public int SeatsNumber { get; set; }
        public string Floor { get; set; }
        public string Description { get; set; }
        public float StartPrice { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }

    }
}
