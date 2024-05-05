using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.Reservation;
using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepos repos;

        public ClientServices(IClientRepos repos) => this.repos = repos;


        #region Reservation Assist 

        public async Task<int> OpenNewReservation(int id)
        {
            var client = await repos.OpenNewReservation(id);

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
            repos.AddToDb(newReservation);
            await repos.SaveChangesAsync();
            return newReservation.Id;
        }

        public async Task UpdateReservationPrice(int reservationId)
        {
            var reservation = await repos.UpdateReservationPrice(reservationId);

            if (reservation != null && (reservation.ReservationCars != null || reservation.ReservationWeddingHalls != null))
            {


                float totalNetPriceCar = reservation.ReservationCars.Sum(car =>
                {
                    var hours = (car.EndTime - car.StartTime).TotalHours;
                    return (float)hours * car.CarRental.PricePerHour;
                });

                float totalNetPriceWedding = reservation.ReservationWeddingHalls.Sum(wedding =>
                {
                    var hours = (wedding.EndTime - wedding.StartTime).TotalHours;
                    return (float)hours * wedding.Room.StartPrice;

                });
                float netPrice =  totalNetPriceWedding + totalNetPriceCar;
                reservation.NetPrice = netPrice;
                float tax =  0.16f * netPrice;
                reservation.TaxAmount = tax;
                reservation.TotalPrice = netPrice + tax;
                repos.UpdateOnDb(reservation);
                await repos.SaveChangesAsync();
            }
        }



        #endregion


        #region Reservation Action

        public async Task<int> AddCarInReservation
            (DateTime StartTime, DateTime EndTime, int CarRentalId, int ClientId, string token)
        {

            try
            {
                if (!token.Equals(UserType.Client.ToString()))
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");
                }

                var car = await repos.AddCarInReservation(CarRentalId);

                if (car.Status.HasFlag(Status.NotAvailable))
                {
                    throw new KeyNotFoundException($"This Car is Not Available Now");
                }

                if (await repos.IsCarAvailable(CarRentalId, StartTime, EndTime))
                {
                    var carInReservation = new ReservationCar()
                    {
                        StartTime = StartTime,
                        EndTime = EndTime,
                        CarRental = car,
                    };

                    var reservationId = await OpenNewReservation(ClientId);

                    var existingReservation = await repos.GetReservationDetails(reservationId);


                    carInReservation.Reservation = existingReservation;

                    car.ReservationCars.Add(carInReservation);
                    repos.AddToDb(carInReservation);
                    int effectedRows = await repos.SaveChangesAsync();
                    await UpdateReservationPrice(reservationId);
                    return effectedRows;
                }


                throw new KeyNotFoundException($"There is a pre-booking for the car, please choose another time");
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating car rental.", ex);

            }
        }


        public async Task<int> AddWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto, string token)
        {

            try
            {
                if (!token.Equals(UserType.Client.ToString()))
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

                    var reservationId = await OpenNewReservation(dto.ClientId);

                    var existingReservation = await repos.GetReservationDetails(reservationId);


                    roomInReservation.Reservation = existingReservation;

                    room.ReservationWeddingHalls.Add(roomInReservation);
                    repos.AddToDb(roomInReservation);

                    if (roomInReservation.WeddingHall.Id != dto.WeddingHallId)
                    {
                        throw new KeyNotFoundException("The room you chose does not belong to the Hall");
                    }

                    int effectedRows = await repos.SaveChangesAsync();

                    if (effectedRows > 0)
                    {
                        await UpdateReservationPrice(reservationId);
                    }

                    return effectedRows;
                }


                throw new KeyNotFoundException($"There is a pre-booking for the room, please choose another time");
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while booking room.", ex);

            }
        }



        public async Task<int> RemoveCarFromReservation(int id, string token)
        {
            try
            {
                if (!token.Equals(UserType.Client.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }
                var carReservation = await repos.RemoveCarFromReservation(id);
                repos.DeleteFromDb(carReservation);
                var affectedRows = await repos.SaveChangesAsync();
                await UpdateReservationPrice(id);
                return affectedRows;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        public async Task<int> RemoveWeddingRoomFromReservation(int id, string token)
        {
            try
            {
                if (!token.Equals(UserType.Client.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }
                var weddingReservation = await repos.RemoveWeddingRoomFromReservation(id);
                repos.DeleteFromDb(weddingReservation);
                var affectedRows = await repos.SaveChangesAsync();
                UpdateReservationPrice(id);
                return  affectedRows;
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }

        }


        public async Task<IEnumerable<ReservationRecordDTO>> GetReservationHistory(JwtPayload token)
        {
            try
            {
                if (!token.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                int userId = int.Parse(token.ElementAt(0).Value.ToString());

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Client.ToString()) || token.IsNullOrEmpty())
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


        public async Task<ReservationDetailsDTO> GetReservationDetails(int id, JwtPayload token)
        {
            try
            {
                if (token == null || !token.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                int userId = int.Parse(token.ElementAt(0).Value.ToString());

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Client.ToString()))
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");
                }

                var reservation = await repos.GetReservationDetails(id);
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



        public async Task<int> Checkout(int id, JwtPayload token)
        {
            try
            {

                if (!token.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Client.ToString()) || token.IsNullOrEmpty())
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var reservation = await repos.Checkout(id);

                reservation.Status = Status.Completed;
                repos.UpdateOnDb(reservation);
                var affectedRows = await repos.SaveChangesAsync();
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