using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.Room
{
    public class CreateOrUpdateRoom
    {
        public int Id { get; set; }
        public string? RoomName { get; set; }
        public string? Image { get; set; }
        public int SeatsNumber { get; set; }
        public string? Floor { get; set; }
        public string? Description { get; set; }
        public float? StartPrice { get; set; }
        public int WeddingHallId { get; set; }
        public Status? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
