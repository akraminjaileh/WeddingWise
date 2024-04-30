namespace WeddingWise_Core.DTO.Account
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
