using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IServices
{
    public interface IAgentServices
    {
        Task<IEnumerable<AgentTransactionRecordDTO>> GetAllTransaction(JwtPayload token);

        Task IncomeAgentAmount(Reservation reservation);
    }
}
