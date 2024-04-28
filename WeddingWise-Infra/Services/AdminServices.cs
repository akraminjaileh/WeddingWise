using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;

namespace WeddingWise_Infra.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepos repos;

        public AdminServices(IAdminRepos repos) => this.repos = repos;

        public Task CreateUser(object user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(object user)
        {
            throw new NotImplementedException();
        }


        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
