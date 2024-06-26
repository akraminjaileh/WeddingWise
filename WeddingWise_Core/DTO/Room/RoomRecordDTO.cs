﻿using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.Room
{
    public class RoomRecordDTO
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Image { get; set; }
        public float StartPrice { get; set; }
        public Status Status { get; set; }
    }
}
