using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepos repos;

        public AgentServices(IAgentRepos repos)
        {
            this.repos = repos;
        }

        public async Task<IEnumerable<AgentTransactionRecordDTO>> GetAllTransaction(JwtPayload token)
        {

            try
            {
                if (!token.Claims.Any())
                {
                    throw new KeyNotFoundException("Invalid Token Claims");
                }

                int userId = int.Parse(token.ElementAt(0).Value.ToString());

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Agent.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var agentTrans = await repos.GetAllTransaction();
                var agentIdRecord= agentTrans.Where(x => x.User.Id == userId);
                var agentList = new List<AgentTransactionRecordDTO>();
                foreach (var item in agentIdRecord)
                {
                    var result = new AgentTransactionRecordDTO
                    {
                        Id = item.Id,
                        Balance = item.Balance,
                        Amount = item.Amount,
                        Fees = item.Fees,
                        TransactionType = item.TransactionType,
                        Status = item.Status,
                        CreationDate = item.CreationDateTime
                    };
                    agentList.Add(result);
                }

                return agentList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve Transaction data", ex);
            }
        }

        

    }
}
