using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.Room
{
    public class RoomDetailsDTO
    {
        public string RoomName { get; set; }
        public string Image { get; set; }
        public int SeatsNumber { get; set; }
        public string Floor { get; set; }
        public string Description { get; set; }
        public float StartPrice { get; set; }
        public Status Status { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
