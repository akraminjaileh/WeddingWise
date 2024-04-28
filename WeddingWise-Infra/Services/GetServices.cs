using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class GetServices : IGetServices
    {
        private readonly IGetRepos repos;

        public GetServices(IGetRepos repos) => this.repos = repos;


        public async Task<IEnumerable<object>> GetAllUser(UserType userType)
        {
            var user = await repos.GetAllUser();

            switch (userType)
            {
                case UserType.Admin:
                    return user.Where(x => x.UserType == UserType.Admin);
                case UserType.Employee:
                    return user.Where(x => x.UserType == UserType.Employee);
                case UserType.Agent:
                    return user.Where(x => x.UserType == UserType.Agent);
                case UserType.Client:
                    return user.Where(x => x.UserType == UserType.Client);
                default:
                    return user;
            }
        }

        public async Task<object> GetOneUserDetails(int id, bool IsAdmin)
        {
            return await repos.GetOneUserDetails(id, IsAdmin);
        }


        public async Task<IEnumerable<object>> GetAllCar()
        {
            return await repos.GetAllCar();
        }

        public async Task<object> GetCarsDetails(int id, bool IsEmployee)
        {
            return await repos.GetCarsDetails(id, IsEmployee);
        }

        public Task<IEnumerable<object>> GetAllWedding()
        {
            throw new NotImplementedException();
        }


        public Task<object> GetWeddingDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}

