using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WeddingWise_Core.Context;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IRepos;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Repos
{
    public class GetRepos : IGetRepos
    {
        private readonly WeddingWiseDbContext context;

        public GetRepos(WeddingWiseDbContext context) => this.context = context;


        #region Get User
        public async Task<IEnumerable<UserRecordDTO>> GetAllUser()
        {
            var user = await context.Users.ToListAsync();
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

        public async Task<UserDetailsDTO> GetOneUserDetails(int id, bool IsAdmin)
        {

            var user = await context.Users

                .Include(u => u.AgentTransactions)
                .Include(u => u.CarRentals)
                .Include(u => u.WeddingHalls)
                .Include(u => u.Reservations)
                .FirstOrDefaultAsync(u => u.Id == id);


            if (user == null)
            {
                return new UserDetailsDTO();
            }

            var result = new UserDetailsDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                City = user.City,
                Address = user.Address,
                Email = user.Email,
                Birthday = user.Birthday,
                Image = user.Image,
                UserType = user.UserType,
                IsActive = user.IsActive,
                CreationDateTime = user.CreationDateTime
            };

            if (IsAdmin)
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
        #endregion


        #region Get Car
        public async Task<IEnumerable<CarRentalRecordDTO>> GetAllCar()
        {
            var cars = await context.CarRentals.ToListAsync();
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
        public async Task<CarRentalDetailsDTO> GetCarsDetails(int id, bool IsAdminOrEmployee)
        {
            var cars = await context.CarRentals
                .Include(c => c.User)
                .Include(r => r.ReservationCars)
                .Include(a => a.Agent)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cars == default)
            {
                throw new KeyNotFoundException("Car with the specified ID not found.");
            }

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
                LicensePlate = cars.LicensePlate,
                Status = cars.Status

            };

            if (IsAdminOrEmployee)
            {

                dto.IsActive = cars.IsActive;
                dto.CreationDateTime = cars.CreationDateTime;

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

                if (!cars.ReservationCars.IsNullOrEmpty())
                {
                    cars.ReservationCars.ForEach(car => dto.ReservationCars.Add(
                      new ReservationCarRecordDTO
                      { Id = car.Id, EndTime = car.EndTime, StartTime = car.StartTime }));

                }

            }
            return dto;
        }
        #endregion


        #region Get Wedding Hall
        public async Task<IEnumerable<WeddingHallRecordDTO>> GetAllWedding()
        {
            var wedding = await context.WeddingHalls.ToListAsync();
            var dto = new List<WeddingHallRecordDTO>();
            wedding.ForEach(wedding => dto.Add(new WeddingHallRecordDTO
            {
                Id = wedding.Id,
                Title = wedding.Title,
                City = wedding.City,
                Review = wedding.Review

            }));
            return dto;
        }
        public async Task<WeddingHallDetailsDTO> GetWeddingDetails(int id, bool IsAdminOrEmployee)
        {
            var wedding = await context.WeddingHalls
               .Include(c => c.User)
               .Include(r => r.ReservationWeddingHalls)
               .Include(a => a.Agent)
               .Include(b => b.Rooms)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (wedding == default)
            {
                throw new KeyNotFoundException("Car with the specified ID not found.");
            }

            var dto = new WeddingHallDetailsDTO()
            {
                Id = wedding.Id,
                Title = wedding.Title,
                Image = wedding.Image,
                Review = wedding.Review,
                City = wedding.City,
                Address = wedding.Address,

            };
            if (!wedding.Rooms.IsNullOrEmpty())
            {
                wedding.Rooms
                    .ForEach(room => dto.Rooms.Add(
                  new RoomRecordDTO
                  {
                      Id = room.Id,
                      Image = room.Image,
                      RoomName = room.RoomName,
                      StartPrice = room.StartPrice,
                      Status = room.Status
                  }));
            }

            if (IsAdminOrEmployee)
            {

                dto.IsActive = wedding.IsActive;
                dto.CreationDateTime = wedding.CreationDateTime;

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

                if (!wedding.ReservationWeddingHalls.IsNullOrEmpty())
                {
                    wedding.ReservationWeddingHalls
                        .ForEach(wed => dto.ReservationWeddingHalls.Add(
                      new ReservationWeddingHallRecordDTO
                      { Id = wed.Id, DayTime = wed.DayTime }));
                }



            }
            return dto;
        }
        #endregion


        #region Get Room 
        public async Task<RoomDetailsDTO> GetRoomDetails(int id, bool IsAdminOrEmployee)
        {
            var room = await context.Rooms
               .FirstOrDefaultAsync(c => c.Id == id);

            if (room == default)
            {
                throw new KeyNotFoundException("Room with the specified ID not found.");
            }

            var dto = new RoomDetailsDTO()
            {
                Id = room.Id,
                RoomName = room.RoomName,
                Image = room.Image,
                SeatsNumber = room.SeatsNumber,
                Floor = room.Floor,
                Description = room.Description,
                StartPrice = room.StartPrice,
                Status = room.Status,

            };

            if (IsAdminOrEmployee)
            {
                dto.IsActive = room.IsActive;
                dto.CreationDateTime = room.CreationDateTime;
            }

            return dto;

        }
        #endregion


    }

}

