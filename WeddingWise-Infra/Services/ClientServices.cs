using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepos repos;

        public ClientServices(IClientRepos repos) => this.repos = repos;


        public async Task<int> OpenNewReservation(int id)
        {
            var client = await repos.OpenNewReservation(id);

            if (!client.UserType.HasFlag(UserType.Client))
            {
                throw new KeyNotFoundException($"Just Client can make a Reservation");
            }
            var reservation = client.Reservations.LastOrDefault(x => x.Status == Status.Pending);
            if (reservation != null)
            {
                return reservation.Id;
            }

            var newReservation = new Reservation { User = client };
            repos.AddToDb(newReservation);
            await repos.SaveChangesAsync();
            return newReservation.Id;
        }


    }
}
