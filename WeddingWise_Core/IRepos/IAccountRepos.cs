using WeddingWise_Core.DTO.Account;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IAccountRepos
    {
        //Effected on databases
        Task<int> SaveChangesAsync();
        void AddToDb(object obj);
        void UpdateOnDb(object obj);

        //Account Management
        Task<User> GetUserById(int id);
        Task<User> Login(LoginDTO dto);
    }
}
