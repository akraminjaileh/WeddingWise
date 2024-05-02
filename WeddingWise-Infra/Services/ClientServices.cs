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
                reservation.NetPrice = totalNetPriceWedding + totalNetPriceCar;

                repos.UpdateOnDb(reservation);
                await repos.SaveChangesAsync();
            }
        }



        #endregion


        #region Reservation Action

        public async Task<int> AddOrUpdateCarInReservation
            (DateTime StartTime, DateTime EndTime, int CarRentalId, int ClientId)
        {

            try
            {

                var car = await repos.AddOrUpdateCarInReservation(CarRentalId);

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

                    var existingReservation = await repos.GetReservationById(reservationId);


                    carInReservation.Reservation = existingReservation; //new Reservation { Id = reservationId };

                    car.ReservationCars.Add(carInReservation);
                    repos.AddToDb(carInReservation);
                    int effectedRows = await repos.SaveChangesAsync();
                    await repos.UpdateReservationPrice(reservationId);
                    return effectedRows;
                }


                throw new KeyNotFoundException($"There is a pre-booking for the car, please choose another time");
            }

            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating car rental.", ex);

            }
        }


        public async Task<int> AddOrUpdateWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto)
        {

            try
            {

                var room = await repos.AddOrUpdateWeddingRoomInReservation(dto.RoomId);

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

                    var existingReservation = await repos.GetReservationById(reservationId);


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
                        await repos.UpdateReservationPrice(reservationId);
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




        #endregion



    }
}