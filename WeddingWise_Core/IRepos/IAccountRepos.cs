using WeddingWise_Core.DTO.Account;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IAccountRepos
    {

        //Account Management
        Task<User> GetUserById(int id);
        Task<User> Login(LoginDTO dto);
    }
}
