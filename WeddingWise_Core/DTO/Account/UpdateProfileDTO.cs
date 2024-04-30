using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.Account
{
    public class UpdateProfileDTO
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public City? City { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Image { get; set; }
        public string? NationalNo { get; set; }
        public UserType? UserType { get; set; }
        public bool? IsActive { get; set; }
    }
}
