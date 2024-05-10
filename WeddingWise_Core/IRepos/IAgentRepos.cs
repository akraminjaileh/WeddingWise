using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WeddingWise_Core.DTO.AgentTransaction;
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
    }
}
