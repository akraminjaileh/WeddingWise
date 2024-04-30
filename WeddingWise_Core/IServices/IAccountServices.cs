using WeddingWise_Core.DTO.Account;

namespace WeddingWise_Core.IServices
{
    public interface IAccountServices
    {
        //Account Management
        Task<int> Registration(RegistrationDTO dto, bool IsAdminOrEmployee);
        Task<int> UpdateProfile(UpdateProfileDTO dto, int id, bool IsAdmin);
        Task<int> DisableAccount(int id);


    }
}
