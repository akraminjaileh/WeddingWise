using Hangfire;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.IDbRepos;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepos repos;
        private readonly IDbRepos dbRepos;
        private readonly IAgentServices agentServices;

        public ClientServices(IClientRepos repos , IDbRepos dbRepos , IAgentServices agentServices)
        {
            this.repos = repos;
            this.dbRepos = dbRepos;
            this.agentServices = agentServices;
        }


        #region Reservation Assist 

        public async Task<int> OpenNewReservation(int userId)
        {
            var client = await repos.GetUserById(userId);

            if (!client.UserType.HasFlag(UserType.Client))
            {
                throw new KeyNotFoundException($"Just Client can make a Reservation");
            }
            var reservation = client.Reservations.LastOrDefault(x => x.Status == Status.Pending);
            if (reservation != null)
            {
                return reservation.Id;
            }

            var newReservation = new Reservation { User = client };
            dbRepos.AddToDb(newReservation);
            await dbRepos.SaveChangesAsync();
            return newReservation.Id;
        }

        public async Task UpdateReservationPrice(int reservationId)
        {
            var reservation = await repos.GetReservationById(reservationId);

            if (reservation.ReservationCars != null || reservation.ReservationWeddingHalls != null)
            {


                float totalNetPriceCar = reservation.ReservationCars
                    .Sum(car =>
                {
                    var hours = (car.EndTime - car.StartTime).TotalHours;
                    return (float)hours * car.CarRental.PricePerHour;
                });

                float totalNetPriceWedding = reservation.ReservationWeddingHalls
                    .Sum(wedding =>
                {
                    var hours = (wedding.EndTime - wedding.StartTime).TotalHours;
                    float normalSweetPrice = 0.7f;  //change if you need
                    float premiumSweetPrice = 1.4f; //change if you need
                    float servicesPrice = 0;

                    if (wedding.SweetType.ToString().ToLower().Contains("premium"))
                    {
                        servicesPrice = premiumSweetPrice * wedding.GuestCount;
                    }
                    servicesPrice = normalSweetPrice * wedding.GuestCount;

                    return ((float)hours * wedding.Room.StartPrice) + servicesPrice;

                });
                float netPrice = totalNetPriceWedding + totalNetPriceCar;
                reservation.NetPrice = netPrice;
                float tax = 0.16f * netPrice;
                reservation.TaxAmount = tax;
                reservation.TotalPrice = netPrice + tax;
                dbRepos.UpdateOnDb(reservation);

            }
        }

        public async Task RefreshReservationStatus()
        {
            
            var reservations = repos.GetPendingReservation();

            foreach (var reservation in reservations)
            {
                var carReservations = reservation.ReservationCars
                      .Where(x => x.Reservation.Id == reservation.Id);

                foreach (var carReservation in carReservations)
                {
                    if (carReservation.EndTime <= DateTime.Now)
                    {
                        carReservation.IsCompleted = true;
                        await dbRepos.SaveChangesAsync();
                    }
                }
                var weddingReservations = reservation.ReservationWeddingHalls
                     .Where(x => x.Reservation.Id == reservation.Id);

                foreach (var weddingReservation in weddingReservations)
                {
                    if (weddingReservation.EndTime <= DateTime.Now)
                    {
                        weddingReservation.IsCompleted = true;
                        await dbRepos.SaveChangesAsync();
                    }
                }
                if (weddingReservations.All(x => x.IsCompleted == true) && carReservations.All(x => x.IsCompleted == true))
                {
                    reservation.Status = Status.Completed;
                    await dbRepos.SaveChangesAsync();
                }

            }

        }




        #endregion


        #region Reservation Action

        public async Task<int> AddCarInReservation(ReservationCarDTO dto, JwtPayload payload)
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

                if (!userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var car = await repos.AddCarInReservation(dto.CarRentalId);

                if (car.Status.HasFlag(Status.NotAvailable))
                {
                    throw new KeyNotFoundException($"This Car is Not Available Now");
                }

                if (await repos.IsCarAvailable(dto.CarRentalId, dto.StartTime, dto.EndTime))
                {
                    var carInReservation = new ReservationCar()
                    {
                        StartTime = dto.StartTime,
                        EndTime = dto.EndTime,
                        CarRental = car,
                    };

                    var reservationId = await OpenNewReservation(userId);

                    var existingReservation = await repos.GetReservationById(reservationId);


                    carInReservation.Reservation = existingReservation;

                    car.ReservationCars.Add(carInReservation);
                    dbRepos.AddToDb(carInReservation);
                    await UpdateReservationPrice(reservationId);
                    return await dbRepos.SaveChangesAsync();

                }


                throw new KeyNotFoundException($"There is a pre-booking for the car, please choose another time");
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating car rental.", ex);

            }
        }


        public async Task<int> AddWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto, JwtPayload payload)
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

                if (!userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var room = await repos.AddWeddingRoomInReservation(dto.RoomId);

                if (room.Status.HasFlag(Status.NotAvailable))
                {
                    throw new KeyNotFoundException($"This Room is Not Available Now");
                }

                if (await repos.IsRoomAvailable(dto.RoomId, dto.StartTime, dto.EndTime))
                {
                    var roomInReservation = new ReservationWeddingHall()
                    {
                        StartTime = dto.StartTime,
                        EndTime = dto.EndTime,
                        SweetType = dto.SweetType,
                        BeverageType = dto.BeverageType,
                        GuestCount = dto.GuestCount,
                    };

                    roomInReservation.WeddingHall = room.WeddingHall;
                    roomInReservation.Room = room;

                    var reservationId = await OpenNewReservation(userId);

                    var existingReservation = await repos.GetReservationById(reservationId);

                    roomInReservation.Reservation = existingReservation;

                    room.ReservationWeddingHalls.Add(roomInReservation);
                    dbRepos.AddToDb(roomInReservation);

                    if (roomInReservation.WeddingHall.Id != dto.WeddingHallId)
                    {
                        throw new KeyNotFoundException("The room you chose does not belong to the Hall");
                    }
                    await UpdateReservationPrice(reservationId);
                    return await dbRepos.SaveChangesAsync();

                }


                throw new KeyNotFoundException($"There is a pre-booking for the room, please choose another time");
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while booking room.", ex);

            }
        }



        public async Task<int> RemoveCarFromReservation(int reservationId, int reservationCarId, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                var userType = payload["UserType"].ToString();

                if (!userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var carReservation = await repos.RemoveCarFromReservation(reservationCarId, reservationId);
                dbRepos.DeleteFromDb(carReservation);
                await UpdateReservationPrice(reservationId);

                return await dbRepos.SaveChangesAsync(); ;

            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public async Task<int> RemoveWeddingRoomFromReservation(int reservationId, int reservationWeddingId, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                var userType = payload["UserType"].ToString();

                if (!userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }
                var weddingReservation = await repos.RemoveWeddingRoomFromReservation(reservationWeddingId, reservationId);

                dbRepos.DeleteFromDb(weddingReservation);
                await UpdateReservationPrice(reservationId);

                return await dbRepos.SaveChangesAsync(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }

        }


        public async Task<IEnumerable<ReservationRecordDTO>> GetReservationHistory(JwtPayload payload)
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

                if (!userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var reservation = await repos.GetReservationHistory(userId);
                var reservationList = new List<ReservationRecordDTO>();
                foreach (var r in reservation)
                {
                    reservationList.Add(new ReservationRecordDTO()
                    {
                        Id = r.Id,
                        PaymentMethod = r.PaymentMethod,
                        Status = r.Status,
                        TotalPrice = r.TotalPrice
                    });
                }

                return reservationList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve reservation data", ex);
            }
        }


        public async Task<ReservationDetailsDTO> GetReservationDetails(int reservationId, JwtPayload payload)
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

                if (!userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var reservation = await repos.GetReservationDetails(reservationId, userId);

                var reservationDetailsDTO = new ReservationDetailsDTO()
                {
                    NetPrice = reservation.NetPrice,
                    DiscountAmount = reservation.DiscountAmount,
                    TaxAmount = reservation.TaxAmount,
                    TotalPrice = reservation.TotalPrice,
                    PromoCode = reservation.PromoCode,
                    PaymentMethod = reservation.PaymentMethod,
                    Status = reservation.Status,
                    ReservationCars = new List<ReservationCarRecordDTO>(),
                    ReservationWeddingHalls = new List<ReservationWeddingHallRecordDTO>()
                };

                if (reservation.ReservationCars.Any())
                {
                    reservationDetailsDTO.ReservationCars.AddRange(reservation.ReservationCars.Select(car => new ReservationCarRecordDTO()
                    {
                        Id = car.Id,
                        StartTime = car.StartTime,
                        EndTime = car.EndTime
                    }));
                }

                if (reservation.ReservationWeddingHalls.Any())
                {
                    reservationDetailsDTO.ReservationWeddingHalls.AddRange(reservation.ReservationWeddingHalls.Select(hall => new ReservationWeddingHallRecordDTO()
                    {
                        Id = hall.Id,
                        StartTime = hall.StartTime,
                        EndTime = hall.EndTime
                    }));
                }

                return reservationDetailsDTO;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve reservation data", ex);
            }
        }



        public async Task<int> Checkout(JwtPayload payload)
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

                if (!userType.Equals(UserType.Client.ToString()) || payload.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }
                var reservationId =await OpenNewReservation(userId);
                var reservation = await repos.GetReservationById(reservationId);
                // if(IsPaymentSuccess) returned by payment provider
                reservation.Status = Status.Confirmed;
                dbRepos.UpdateOnDb(reservation);
                var affectedRows = await dbRepos.SaveChangesAsync();

                if (affectedRows > 0)
                {
                    await agentServices.IncomeAgentAmount(reservation);
                }
                
                return affectedRows;
                
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion



    }
}