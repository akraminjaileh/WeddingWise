using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepos repos;

        public AdminServices(IAdminRepos repos)
        {
            this.repos = repos;
        }
        public Task<List<User>> FindAllUser()
        {
            return repos.FindAllUser();
        }
    }
}
