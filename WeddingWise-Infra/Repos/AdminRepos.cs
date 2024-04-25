using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Repos
{
    public class AdminRepos: IAdminRepos
    {
        private readonly WeddingWiseDbContext context;

        public AdminRepos(WeddingWiseDbContext context)
        {
            this.context = context;
        }

        public async Task<List<User>> FindAllUser()
        {
            return await context.Users.ToListAsync();

        }
    }

}
