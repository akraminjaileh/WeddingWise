using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.AgentTransaction;

namespace WeddingWise_Core.IServices
{
    public interface IAgentServices
    {
        Task<IEnumerable<AgentTransactionRecordDTO>> GetAllTransaction(JwtPayload token);

        Task TransferAgentTransaction();
    }
}
