using WeddingWise_Core.DTO.Account;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;

namespace WeddingWise_Infra.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepos repos;

        public AccountServices(IAccountRepos repos) => this.repos = repos;



        #region User Management
        public async Task<int> Registration(RegistrationDTO dto, bool IsAdminOrEmployee)
        {
            int affectedRows = await repos.Registration(dto, IsAdminOrEmployee);

            return affectedRows;
        }

        public async Task<int> UpdateProfile(UpdateProfileDTO dto, int id, bool IsAdmin)
        {
            int affectedRows = await repos.UpdateProfile(dto, id, IsAdmin);

            return affectedRows;
        }


        public async Task<int> DisableAccount(int id)
        {
            int affectedRows = await repos.DisableAccount(id);

            return affectedRows;
        }

        #endregion



    }
}
