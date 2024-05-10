using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;
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
                    transaction.ReservationCar = reservation.ReservationCars
                        .Where(x => x.CarRental.Agent == agentIdInUser).First();
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
                    transaction.ReservationWeddingHall = reservation.ReservationWeddingHalls
                        .Where(x => x.WeddingHall.Agent == agentIdInUser).First();
                    dbRepos.UpdateOnDb(transaction);
                    await dbRepos.SaveChangesAsync();

                }
            }

        }

        public async Task UpdateTransactionStatus()
        {
            var agentTransactions = await repos.GetAllPendingTransaction();
            foreach (var ag in agentTransactions)
            {

                if (ag.ReservationCar != null && ag.ReservationCar.EndTime <= DateTime.Now)
                {
                    ag.Status = Status.Available;
                }
                if (ag.ReservationWeddingHall != null && ag.ReservationWeddingHall.EndTime <= DateTime.Now)
                {
                    ag.Status = Status.Available;
                }
                await dbRepos.SaveChangesAsync();
            }

        }

        #endregion


        #region Agent Action
        public async Task<IEnumerable<AgentTransactionRecordDTO>> GetAllTransaction(JwtPayload payload)
        {

            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }
                int userId;

                if (!int.TryParse(payload["UserId"].ToString(), out userId))
                    throw new UnauthorizedAccessException("Invalid Token Claims");

                var userType = payload["UserType"].ToString();

                if (!userType.Equals(UserType.Agent.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var agentTrans = await repos.GetAllTransaction(userId);
                var agentList = new List<AgentTransactionRecordDTO>();
                foreach (var item in agentTrans)
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


        public async Task<AgentTransactionDetailsDTO> GetTransactionDetails(JwtPayload payload, int agentTransactionId)
        {

            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }


                var userType = payload["UserType"].ToString();

                if (!userType.Equals(UserType.Agent.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var agentTrans = await repos.GetTransactionDetails(agentTransactionId);

                var result = new AgentTransactionDetailsDTO
                {
                    Id = agentTrans.Id,
                    TotalAmount = agentTrans.TotalAmount,
                    Amount = agentTrans.Amount,
                    Fees = agentTrans.Fees,
                    TransactionType = agentTrans.TransactionType,
                    Status = agentTrans.Status,
                    CreationDate = agentTrans.CreationDateTime
                };

                if (agentTrans.ReservationCar != null)
                {
                    result.ReservationCar = new()
                    {
                        StartTime = agentTrans.ReservationCar.StartTime,
                        EndTime = agentTrans.ReservationCar.EndTime,
                        CarRentalId = agentTrans.ReservationCar.CarRental.Id
                    };
                }

                if (agentTrans.ReservationWeddingHall != null)
                {
                    result.ReservationWedding = new ReservationWeddingHallWithRoomDTO
                    {
                        WeddingHallId = agentTrans.ReservationWeddingHall.WeddingHall.Id,
                        StartTime = agentTrans.ReservationWeddingHall.StartTime,
                        EndTime = agentTrans.ReservationWeddingHall.EndTime,
                        BeverageType = agentTrans.ReservationWeddingHall.BeverageType,
                        SweetType = agentTrans.ReservationWeddingHall.SweetType,
                        GuestCount = agentTrans.ReservationWeddingHall.GuestCount,
                        RoomId = agentTrans.ReservationWeddingHall.Room.Id

                    };


                    if (agentTrans.ReservationWeddingHall.Room != null)
                    {
                        result.Room = new RoomRecordDTO
                        {
                            Id = agentTrans.ReservationWeddingHall.Room.Id,
                            RoomName = agentTrans.ReservationWeddingHall.Room.RoomName,
                            StartPrice = agentTrans.ReservationWeddingHall.Room.StartPrice,
                            Status = agentTrans.ReservationWeddingHall.Room.Status
                        };

                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve AgentTransaction data", ex);
            }
        }


        public async Task<CheckBalanceDTO> CheckBalance(JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }
                int userId;

                if (!int.TryParse(payload["UserId"].ToString(), out userId))
                    throw new UnauthorizedAccessException("Invalid Token Claims");

                var userType = payload["UserType"].ToString();

                if (!userType.Equals(UserType.Agent.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var agentTrans = await repos.GetAllTransaction(userId);
                var balance = new CheckBalanceDTO();

                balance.PendingBalance = agentTrans
                    .Where(x => x.Status == Status.Pending).Sum(x => x.TotalAmount);

                balance.AvailableBalance = agentTrans.Where(y => y.Status == Status.Available).Sum(x =>
                {
                    float incomeBalance = 0, outcomeBalance = 0;

                    if (x.TransactionType == TransactionType.Income)
                    {
                        incomeBalance = x.TotalAmount;
                    }
                    if (x.TransactionType == TransactionType.Outcome)
                    {
                        outcomeBalance = x.TotalAmount;
                    }
                    return incomeBalance - outcomeBalance;
                });

                balance.TotalBalance = balance.AvailableBalance + balance.PendingBalance;

                return balance;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve AgentTransaction data", ex);
            }
        }


        public async Task<int> UpdateCar(CreateOrUpdateCarDTO dto, int carId, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }
                

                var userType = payload["UserType"].ToString();

                if (userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var car = await repos.UpdateCar(carId);

                if (car == null)
                {
                    throw new KeyNotFoundException($"Car with ID {carId} not found.");
                }

                car.Title = dto.Title ?? car.Title;
                car.Image = dto.Image ?? car.Image;
                car.Brand = dto.Brand ?? car.Brand;
                car.Color = dto.Color ?? car.Color;
                car.Description = dto.Description ?? car.Description;
                car.Modal = dto.Modal ?? car.Modal;
                car.City = dto.City ?? car.City;
                car.Address = dto.Address ?? car.Address;
                car.PricePerHour = dto.PricePerHour ?? car.PricePerHour;
                car.Status = dto.Status ?? car.Status;

                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
                {
                    car.Year = dto.Year ?? car.Year;
                    car.LicensePlate = dto.LicensePlate ?? car.LicensePlate;
                    car.IsActive = dto.IsActive;
                }

                dbRepos.AddToDb(car);
                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to update car rental due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating car rental.", ex);
            }
        }


        public async Task<int> UpdateWeddingHall(CreateOrUpdateWeddingHallDTO dto, int weddingId, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }


                var userType = payload["UserType"].ToString();

                if (userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var wedding = await repos.UpdateWeddingHall(weddingId);

                wedding.Title = dto.Title ?? wedding.Title;
                wedding.Image = dto.Image ?? wedding.Image;

                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
                {
                    wedding.City = dto.City ?? wedding.City;
                    wedding.Address = dto.Address ?? wedding.Address;
                    wedding.Review = dto.Review ?? wedding.Review;
                    wedding.IsActive = dto.IsActive;
                }

                dbRepos.UpdateOnDb(wedding);
                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to update Wedding due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating Wedding.", ex);
            }
        }

        public async Task<int> UpdateRoom(CreateOrUpdateRoom dto, int roomId, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }


                var userType = payload["UserType"].ToString();

                if (userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var room = await repos.UpdateRoom(roomId);

                room.RoomName = dto.RoomName ?? room.RoomName;
                room.Image = dto.Image ?? room.Image;
                room.SeatsNumber = dto.SeatsNumber;
                room.Floor = dto.Floor ?? room.Floor;
                room.Description = dto.Description ?? room.Description;
                room.StartPrice = dto.StartPrice ?? room.StartPrice;
                room.Status = dto.Status ?? room.Status;

                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
                {

                    room.IsActive = dto.IsActive;
                }

                dbRepos.UpdateOnDb(room);
                int affectedRows = await dbRepos.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to update Room due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while updating Room.", ex);
            }
        }

        #endregion

    }
}
