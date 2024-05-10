using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.WeddingHall
{
    public class CreateOrUpdateWeddingHallDTO
    {
 
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Review { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public int UserId { get; set; }
        public int AgentId { get; set; }
        public bool IsActive { get; set; }
    }
}
