using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IAgentRepos
    {

        Task<IEnumerable<AgentTransaction>> GetAllTransaction(int agentId);

        Task<IEnumerable<Reservation>> GetConfirmedReservation();

        Task<IEnumerable<User>> GetAgent();

        Task<IEnumerable<AgentTransaction>> GetAllPendingTransaction();

        Task<AgentTransaction> GetTransactionDetails(int transactionId);

        Task<CarRental> UpdateCar(int carId);

        Task<WeddingHall> UpdateWeddingHall(int weddingId);

        Task<Room> UpdateRoom(int roomId);
    }
}
