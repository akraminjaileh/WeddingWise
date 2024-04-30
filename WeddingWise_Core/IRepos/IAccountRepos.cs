using WeddingWise_Core.DTO.Account;
using WeddingWise_Core.DTO.User;

namespace WeddingWise_Core.IRepos
{
    public interface IAccountRepos
    {
        //Account Management
        Task<int> Registration(RegistrationDTO dto, bool IsAdminOrEmployee);
        Task<int> UpdateProfile(UpdateProfileDTO dto, int id, bool IsAdmin);
        Task<int> DisableAccount(int id);
    }
}
