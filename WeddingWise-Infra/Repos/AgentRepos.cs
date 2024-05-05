using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;


namespace WeddingWise_Infra.Repos
{
    public class AgentRepos : IAgentRepos
    {
        private readonly WeddingWiseDbContext context;

        public AgentRepos(WeddingWiseDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AgentTransaction>> GetAllTransaction()
        {
            return await context.Transactions.ToListAsync();
        }

    }
}
