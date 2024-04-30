using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Repos
{
    public class ClientRepos : IClientRepos
    {
        private readonly WeddingWiseDbContext context;

        public ClientRepos(WeddingWiseDbContext context) => this.context = context;

        public void AddToDb(object obj)
        {
            context.Add(obj);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await context.SaveChangesAsync();
        }

        public async Task<User> OpenNewReservation(int id)
        {
            var client = await context.Users
                .Include(r => r.Reservations).FirstOrDefaultAsync(c => c.Id == id);
            
            if (client == null)
            {
                throw new KeyNotFoundException($"Client with ID {id} not found.");
            }
            return client;

        }
    }
}
