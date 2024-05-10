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


        #region Agent Assist

        public async Task<IEnumerable<AgentTransaction>> GetAllPendingTransaction()
        {
            return await context.AgentTransactions
                .Where(x => x.Status == Status.Pending).ToListAsync();
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

        #endregion


        #region Agent Action

        public async Task<IEnumerable<AgentTransaction>> GetAllTransaction(int agentId)
        {
            return await context.AgentTransactions
                .Where(x => x.Agent.Id == agentId).ToListAsync();
        }

        public async Task<AgentTransaction> GetTransactionDetails(int transactionId)
        {
            var agentTransaction = await context.AgentTransactions
                           .FirstOrDefaultAsync(x => x.Id == transactionId);

            if (agentTransaction == null)
            {
                throw new KeyNotFoundException($"Agent Transaction with ID {transactionId} not found.");
            }
            return agentTransaction;
        }


        public async Task<CarRental> UpdateCar(int carId)
        {
            var car = await context.CarRentals.FirstOrDefaultAsync(x => x.Id == carId);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {carId} not found.");
            }

            return car;
        }

        public async Task<WeddingHall> UpdateWeddingHall(int weddingId)
        {
            var wedding = await context.WeddingHalls.FirstOrDefaultAsync(x => x.Id == weddingId);
            if (wedding == null)
            {
                throw new KeyNotFoundException($"Wedding with ID {weddingId} not found.");
            }

            return wedding;
        }


        public async Task<Room> UpdateRoom(int roomId)
        {
            var room = await context.Rooms.FirstOrDefaultAsync(x => x.Id == roomId);

            if (room == null)
            {
                throw new KeyNotFoundException($"Room with ID {roomId} not found.");
            }

            return room;
        }

        #endregion


    }
}

