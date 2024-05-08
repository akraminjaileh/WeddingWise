using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WeddingWise_Core.Context;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;


namespace WeddingWise_Infra.Repos
{
    public class AgentRepos : IAgentRepos
    {
        private readonly WeddingWiseDbContext context;

        public AgentRepos(WeddingWiseDbContext context) => this.context = context;


        public async Task<IEnumerable<AgentTransaction>> GetAllTransaction()
        {
            return await context.AgentTransactions.ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetConfirmedReservation()
        {
            var reservation = await context.Reservations
                .Where(x => x.Status.Equals(Status.Confirmed)).ToListAsync();
            if (reservation.IsNullOrEmpty())
            {
                throw new KeyNotFoundException($"reservation not found.");
            }

            return reservation;
        }

        public async Task<IEnumerable<User>> GetAgent()
        {
            var agent = await context.Users
                .Where(x => x.UserType.Equals(UserType.Agent)).ToListAsync();
            if (agent == null)
            {
                throw new KeyNotFoundException($"agent not found.");
            }

            return agent;
        }

    }
}
