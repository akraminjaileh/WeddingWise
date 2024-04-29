using WeddingWise_Core.DTO.User;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;

namespace WeddingWise_Infra.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepos repos;

        public AdminServices(IAdminRepos repos) => this.repos = repos;

        public async Task<int> CreateUser(CreateOrUpdateUserDTO dto)
        {
           int affectedRows = await repos.CreateUser(dto);

            return affectedRows;
        }

        public async Task<int> UpdateUser(CreateOrUpdateUserDTO dto,int id, bool IsAdmin)
        {
            int affectedRows = await repos.UpdateUser(dto,id,IsAdmin);

            return affectedRows;
        }


        public Task<int> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
