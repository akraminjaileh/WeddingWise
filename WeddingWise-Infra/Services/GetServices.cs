using Microsoft.IdentityModel.Tokens;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class GetServices : IGetServices
    {
        private readonly IGetRepos repos;

        public GetServices(IGetRepos repos) => this.repos = repos;


        #region Get User

        public async Task<IEnumerable<UserRecordDTO>> GetAllUser(string token)
        {
            try
            {
                if (token.Equals(UserType.Admin.ToString()) || token.Equals(UserType.Employee.ToString()))
                {

                    var user = await repos.GetAllUser();
                    var result = new List<UserRecordDTO>();
                    foreach (var u in user)
                    {
                        result.Add(new UserRecordDTO()
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Image = u.Image,
                            Phone = u.Phone,
                            UserType = u.UserType,
                        });
                    }

                    return result;
                }
                throw new UnauthorizedAccessException("User does not have sufficient permissions.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve user data", ex);
            }
        }


        public async Task<UserDetailsDTO> GetOneUserDetails(int id, string token)
        {
            try
            {
                if (token.Equals(UserType.Employee.ToString()) || token.Equals(UserType.Admin.ToString()) || token.Equals(UserType.Agent.ToString()))
                {
                    var user = await repos.GetOneUserDetails(id);

                    var result = new UserDetailsDTO()
                    {
                        Name = user.Name,
                        Phone = user.Phone,
                        City = user.City,
                        Address = user.Address,
                    };

                    if (token.Equals(UserType.Employee.ToString()) || token.Equals(UserType.Admin.ToString()))
                    {
                        result.Email = user.Email;
                        result.Birthday = user.Birthday;
                        result.Image = user.Image;
                        result.UserType = user.UserType;
                        result.IsActive = user.IsActive;
                        result.CreationDateTime = user.CreationDateTime;
                    }

                    if (token.Equals(UserType.Admin.ToString()))
                    {
                        result.NationalNo = user.NationalNo;
                    }

                    if (UserType.Agent == result.UserType)
                    {
                        if (!user.AgentTransactions.IsNullOrEmpty())
                        {
                            user.AgentTransactions.ForEach(transaction =>
                            result.AgentTransactions.Add(
                              new AgentTransactionRecordDTO()
                              {
                                  Id = transaction.Id,
                                  Balance = transaction.Balance,
                                  TransactionType = transaction.TransactionType,
                                  Amount = transaction.Amount,
                                  Fees = transaction.Fees,
                                  Status = transaction.Status,
                              }));
                        }

                        if (!user.CarRentals.IsNullOrEmpty())
                        {
                            result.CarRentals.ForEach(car =>
                                result.CarRentals.Add(new CarRentalRecordDTO()
                                {
                                    Id = car.Id,
                                    Title = car.Title,
                                    City = car.City,
                                    PricePerHour = car.PricePerHour,
                                    Year = car.Year
                                }));
                        }

                        if (!user.WeddingHalls.IsNullOrEmpty())
                        {
                            result.WeddingHalls.ForEach(wedding =>
                                result.WeddingHalls.Add(new WeddingHallRecordDTO()
                                {
                                    Id = wedding.Id,
                                    Title = wedding.Title,
                                    City = wedding.City,
                                    Review = wedding.Review
                                }));
                        }
                    }

                    if (UserType.Client == result.UserType)
                    {
                        if (!user.Reservations.IsNullOrEmpty())
                        {
                            user.Reservations.ForEach(r => result.Reservations.Add(

                                new ReservationRecordDTO()
                                {
                                    Id = r.Id,
                                    TotalPrice = r.TotalPrice,
                                    PaymentMethod = r.PaymentMethod,
                                    Status = r.Status
                                }
                            ));
                        }
                    }

                    return result;
                }
                else
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve user data", ex);
            }
        }


        #endregion


        #region Get Car

        public async Task<IEnumerable<CarRentalRecordDTO>> GetAllCar()
        {
            var cars = await repos.GetAllCar();

            var dto = new List<CarRentalRecordDTO>();
            foreach (var car in cars)
            {
                dto.Add(new CarRentalRecordDTO()
                {
                    Id = car.Id,
                    Title = car.Title,
                    City = car.City,
                    PricePerHour = car.PricePerHour,
                    Year = car.Year,
                    Status = car.Status
                });
            };
            return dto;
        }

        public async Task<CarRentalDetailsDTO> GetCarsDetails(int id, string token)
        {
            try
            {
                var cars = await repos.GetCarsDetails(id);

                var dto = new CarRentalDetailsDTO()
                {
                    Id = cars.Id,
                    Title = cars.Title,
                    Image = cars.Image,
                    Brand = cars.Brand,
                    Color = cars.Color,
                    Description = cars.Description,
                    Modal = cars.Modal,
                    Year = cars.Year,
                    City = cars.City,
                    Address = cars.Address,
                    PricePerHour = cars.PricePerHour,
                    Status = cars.Status
                };
                if (token.IsNullOrEmpty())
                {
                    return dto;
                }

                if (token.Equals(UserType.Employee.ToString()) || token.Equals(UserType.Admin.ToString()))
                {
                    dto.LicensePlate = cars.LicensePlate;
                    dto.CreationDateTime = cars.CreationDateTime;

                    if (!cars.ReservationCars.IsNullOrEmpty())
                    {
                        cars.ReservationCars.ForEach(car => dto.ReservationCars.Add(
                          new ReservationCarRecordDTO
                          {
                              Id = car.Id,
                              EndTime = car.EndTime,
                              StartTime = car.StartTime
                          }));
                    }
                }

                if (token.Equals(UserType.Admin.ToString()) || token.Equals(UserType.Employee.ToString()))
                {
                    dto.IsActive = cars.IsActive;

                    if (cars.User != null)
                    {
                        dto.User = new UserRecordDTO
                        {
                            Id = cars.User.Id,
                            Name = cars.User.Name,
                            Phone = cars.User.Phone
                        };
                    }

                    if (cars.Agent != null)
                    {
                        dto.Agent = new UserRecordDTO
                        {
                            Id = cars.Agent.Id,
                            Name = cars.Agent.Name,
                            Phone = cars.Agent.Phone
                        };
                    }
                }

                return dto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while retrieving car details: {ex.Message}");
            }
        }

        #endregion


        #region Get Wedding Hall
        public async Task<IEnumerable<WeddingHallRecordDTO>> GetAllWedding()
        {
            var weddings = await repos.GetAllWedding();
            var dto = new List<WeddingHallRecordDTO>();

            foreach (var wedding in weddings)
            {
                dto.Add(new WeddingHallRecordDTO
                {
                    Id = wedding.Id,
                    Title = wedding.Title,
                    City = wedding.City,
                    Review = wedding.Review
                });
            }

            return dto;
        }

        public async Task<WeddingHallDetailsDTO> GetWeddingDetails(int id, string token)
        {
            try
            {
                var wedding = await repos.GetWeddingDetails(id);

                var dto = new WeddingHallDetailsDTO()
                {
                    Id = wedding.Id,
                    Title = wedding.Title,
                    Image = wedding.Image,
                    Review = wedding.Review,
                    City = wedding.City,
                    Address = wedding.Address,
                };

                if (wedding.Rooms != null && wedding.Rooms.Any())
                {
                    wedding.Rooms.ForEach(room => dto.Rooms.Add(new RoomRecordDTO
                    {
                        Id = room.Id,
                        Image = room.Image,
                        RoomName = room.RoomName,
                        StartPrice = room.StartPrice,
                        Status = room.Status
                    }));
                }

                if (token.IsNullOrEmpty())
                {
                    return dto;
                }

                if (token.Equals(UserType.Admin.ToString()) || token.Equals(UserType.Employee.ToString()))
                {
                    dto.IsActive = wedding.IsActive;
                    dto.CreationDateTime = wedding.CreationDateTime;

                    if (wedding.ReservationWeddingHalls != null && wedding.ReservationWeddingHalls.Any())
                    {
                        wedding.ReservationWeddingHalls.ForEach(wed => dto.ReservationWeddingHalls.Add(new ReservationWeddingHallRecordDTO
                        {
                            Id = wed.Id,
                            StartTime = wed.StartTime,
                            EndTime = wed.EndTime
                        }));
                    }

                    if (wedding.User != null)
                    {
                        dto.User = new UserRecordDTO
                        {
                            Id = wedding.User.Id,
                            Name = wedding.User.Name,
                            Phone = wedding.User.Phone
                        };
                    }

                    if (wedding.Agent != null)
                    {
                        dto.Agent = new UserRecordDTO
                        {
                            Id = wedding.Agent.Id,
                            Name = wedding.Agent.Name,
                            Phone = wedding.Agent.Phone
                        };
                    }
                }
                return dto;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Failed to retrieve wedding details.", ex);
            }
        }


        #endregion


        #region Get Room 
        public async Task<RoomDetailsDTO> GetRoomDetails(int id, string token)
        {
            try
            {
                var room = await repos.GetRoomDetails(id);

                var dto = new RoomDetailsDTO()
                {
                    RoomName = room.RoomName,
                    Image = room.Image,
                    SeatsNumber = room.SeatsNumber,
                    Floor = room.Floor,
                    Description = room.Description,
                    StartPrice = room.StartPrice,
                    Status = room.Status,
                };
                if (token.IsNullOrEmpty())
                {
                    return dto;
                }

                if (token.Equals(UserType.Admin.ToString()) || token.Equals(UserType.Employee.ToString()))
                {
                    dto.IsActive = room.IsActive;
                    dto.CreationDateTime = room.CreationDateTime;
                }

                return dto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to retrieve details for room ID {id}.", ex);
            }
        }

        #endregion


    }
}

