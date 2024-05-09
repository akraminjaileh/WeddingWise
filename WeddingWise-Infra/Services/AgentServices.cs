using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.Helper;
using WeddingWise_Core.IDbRepos;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class AgentServices : IAgentServices
    {
        private readonly IAgentRepos repos;
        private readonly IDbRepos dbRepos;

        public AgentServices(IAgentRepos repos, IDbRepos dbRepos)
        {
            this.repos = repos;
            this.dbRepos = dbRepos;
        }


        #region Agent Assist

        public async Task IncomeAgentAmount(Reservation reservation)
        {

            var agent = await repos.GetAgent();


            if (reservation.ReservationCars != null)
            {

                var agentIdInCar = reservation.ReservationCars
                                          .Select(x => x.CarRental.Agent.Id).ToList();

                foreach (var a in agentIdInCar)
                {
                    var agentIdInUser = agent.Where(x => x.Id == a).First();

                    float totalNetPriceCar = reservation.ReservationCars
                         .Where(x => x.CarRental.Agent == agentIdInUser)
                         .Sum(car =>
                         {
                             var hours = (car.EndTime - car.StartTime).TotalHours;
                             return (float)hours * car.CarRental.PricePerHour;
                         });

                    var transaction = new AgentTransaction();

                    transaction.Amount = totalNetPriceCar;
                    transaction.Fees = FixedPrices.fees * transaction.Amount;
                    transaction.TotalAmount = transaction.Amount - transaction.Fees;
                    transaction.Agent = agentIdInUser;
                    transaction.TransactionType = TransactionType.Income;
                    dbRepos.UpdateOnDb(transaction);
                    await dbRepos.SaveChangesAsync();

                }
            }


            if (reservation.ReservationWeddingHalls != null)
            {

                var agentIdInWedding = reservation.ReservationWeddingHalls
                                          .Select(x => x.WeddingHall.Agent.Id).ToList();

                foreach (var a in agentIdInWedding)
                {

                    var agentIdInUser = agent.Where(x => x.Id == a).First();

                    float totalNetPriceWedding = reservation.ReservationWeddingHalls
                        .Where(x => x.WeddingHall.Agent == agentIdInUser)
                        .Sum(wedding =>
                        {
                            var hours = (wedding.EndTime - wedding.StartTime).TotalHours;
                            float normalSweetPrice = FixedPrices.normalSweetPrice;
                            float premiumSweetPrice = FixedPrices.premiumSweetPrice;
                            float servicesPrice = 0;

                            if (wedding.SweetType.ToString().ToLower().Contains("premium"))
                            {
                                servicesPrice = premiumSweetPrice * wedding.GuestCount;
                            }
                            servicesPrice = normalSweetPrice * wedding.GuestCount;

                            return ((float)hours * wedding.Room.StartPrice) + servicesPrice;

                        });

                    var transaction = new AgentTransaction();

                    transaction.Amount = totalNetPriceWedding;
                    transaction.Fees = FixedPrices.fees * transaction.Amount;
                    transaction.TotalAmount = transaction.Amount - transaction.Fees;
                    transaction.Agent = agentIdInUser;
                    transaction.TransactionType = TransactionType.Income;
                    dbRepos.UpdateOnDb(transaction);
                    await dbRepos.SaveChangesAsync();

                }
            }

        }


        #endregion


        #region Agent Action
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
                var agentIdRecord = agentTrans.Where(x => x.Agent.Id == userId);
                var agentList = new List<AgentTransactionRecordDTO>();
                foreach (var item in agentIdRecord)
                {
                    var result = new AgentTransactionRecordDTO
                    {
                        Id = item.Id,
                        TotalAmount = item.TotalAmount,
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
                throw new ApplicationException("Failed to retrieve AgentTransaction data", ex);
            }
        }

        #endregion



    }
}
