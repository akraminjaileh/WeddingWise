using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.Context;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Repos
{
    public class AdminRepos : IAdminRepos
    {
        private readonly WeddingWiseDbContext context;

        public AdminRepos(WeddingWiseDbContext context) => this.context = context;



        #region CarRental Management

        public async Task<int> CreateCar(CreateOrUpdateCarDTO dto)
        {
            try
            {
                var car = new CarRental
                {
                    Title = dto.Title,
                    Image = dto.Image,
                    Brand = dto.Brand,
                    Color = dto.Color,
                    Modal = dto.Modal,
                    Year = dto.Year.Value,
                    LicensePlate = dto.LicensePlate,
                    City = dto.City.Value,
                    Address = dto.Address,
                    PricePerHour = dto.PricePerHour.Value
                };

                if (dto.UserId > 0)
                {
                    var user = await context.Users.FindAsync(dto.UserId);

                    if (user == null)
                    {
                        throw new KeyNotFoundException($"User with ID {dto.UserId} not found.");
                    }

                    if (user.UserType == UserType.Employee || user.UserType == UserType.Employee)
                    {
                        car.User = user;
                    }
                    else
                        throw new KeyNotFoundException($"Just Admin or Employee can be Create a Car");

                }

                if (dto.AgentId > 0)
                {
                    var agent = await context.Users.FindAsync(dto.AgentId);
                    if (agent == null)
                    {
                        throw new KeyNotFoundException($"Agent with ID {dto.AgentId} not found.");
                    }
                    if (agent.UserType == UserType.Agent)
                    {
                        car.Agent = agent;
                    }
                    else
                        throw new KeyNotFoundException($"Agent with ID {dto.AgentId} not found.");

                }

                await context.CarRentals.AddAsync(car);
                int affectedRows = await context.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to create car rental due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating car rental.", ex);
            }
        }



        public async Task<int> UpdateCar(CreateOrUpdateCarDTO dto, int id, bool IsAdmin)
        {
            try
            {
                var car = await context.CarRentals.FirstOrDefaultAsync(x => x.Id == id);

                if (car == null)
                {
                    throw new KeyNotFoundException($"Car with ID {id} not found.");
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

                if (IsAdmin)
                {
                    car.Year = dto.Year ?? car.Year;
                    car.LicensePlate = dto.LicensePlate ?? car.LicensePlate;
                    car.IsActive = dto.IsActive;
                }

                context.Update(car);
                int affectedRows = await context.SaveChangesAsync();
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



        public async Task<int> DeleteCar(int id)
        {
            try
            {
                var car = await context.CarRentals.FirstOrDefaultAsync(x => x.Id == id);
                if (car != null)
                {
                    car.IsActive = false;
                    context.Update(car);
                    var affectedRows = await context.SaveChangesAsync();
                    return affectedRows;
                }

                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


        #region WeddingHall Management
        public async Task<int> CreateWeddingHall(CreateOrUpdateWeddingHallDTO dto)
        {
            try
            {
                var wedding = new WeddingHall
                {
                    Title = dto.Title,
                    City = dto.City.Value,
                    Address = dto.Address,
                };

                if (dto.UserId > 0)
                {
                    var user = await context.Users.FindAsync(dto.UserId);

                    if (user == null)
                    {
                        throw new KeyNotFoundException($"User with ID {dto.UserId} not found.");
                    }

                    if (user.UserType == UserType.Employee || user.UserType == UserType.Employee)
                    {
                        wedding.User = user;
                    }
                    else
                        throw new KeyNotFoundException($"Just Admin or Employee can be Create a Car");

                }

                if (dto.AgentId > 0)
                {
                    var agent = await context.Users.FindAsync(dto.AgentId);
                    if (agent == null)
                    {
                        throw new KeyNotFoundException($"Agent with ID {dto.AgentId} not found.");
                    }
                    if (agent.UserType == UserType.Agent)
                    {
                        wedding.Agent = agent;
                    }
                    else
                        throw new KeyNotFoundException($"Agent with ID {dto.AgentId} not found.");

                }

                await context.WeddingHalls.AddAsync(wedding);
                int affectedRows = await context.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to create wedding due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating wedding.", ex);
            }
        }

        public async Task<int> UpdateWeddingHall(CreateOrUpdateWeddingHallDTO dto, int id, bool IsAdmin)
        {
            try
            {
                var wedding = await context.WeddingHalls.FirstOrDefaultAsync(x => x.Id == id);

                if (wedding == null)
                {
                    throw new KeyNotFoundException($"Wedding with ID {id} not found.");
                }

                wedding.Title = dto.Title ?? wedding.Title;
                wedding.Image = dto.Image ?? wedding.Image;

                if (IsAdmin)
                {
                    wedding.City = dto.City ?? wedding.City;
                    wedding.Address = dto.Address ?? wedding.Address;
                    wedding.Review = dto.Review ?? wedding.Review;
                    wedding.IsActive = dto.IsActive;
                }

                context.Update(wedding);
                int affectedRows = await context.SaveChangesAsync();
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

        public async Task<int> DeleteWeddingHall(int id)
        {
            try
            {
                var wedding = await context.WeddingHalls.FirstOrDefaultAsync(x => x.Id == id);
                if (wedding != null)
                {
                    wedding.IsActive = false;
                    context.Update(wedding);
                    var affectedRows = await context.SaveChangesAsync();
                    return affectedRows;
                }

                throw new KeyNotFoundException($"Wedding with ID {id} not found.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


        #region Room Management
        public async Task<int> CreateRoom(CreateOrUpdateRoom dto)
        {
            try
            {
                var room = new Room
                {
                    RoomName = dto.RoomName,
                    SeatsNumber = dto.SeatsNumber,
                    Floor = dto.Floor,
                    StartPrice = dto.StartPrice.Value,
                };
                room.WeddingHall.Id = dto.WeddingHallId;


                await context.Rooms.AddAsync(room);
                int affectedRows = await context.SaveChangesAsync();
                return affectedRows;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to create Room due to database constraints.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while creating Room.", ex);
            }
        }

        public async Task<int> UpdateRoom(CreateOrUpdateRoom dto, int id, bool IsAdmin)
        {
            try
            {
                var room = await context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

                if (room == null)
                {
                    throw new KeyNotFoundException($"Room with ID {id} not found.");
                }
                room.RoomName = dto.RoomName ?? room.RoomName;
                room.Image = dto.Image ?? room.Image;
                room.SeatsNumber = dto.SeatsNumber;
                room.Floor = dto.Floor ?? room.Floor;
                room.Description = dto.Description ?? room.Description;
                room.StartPrice = dto.StartPrice ?? room.StartPrice;
                room.Status = dto.Status ?? room.Status;

                if (IsAdmin)
                {

                    room.IsActive = dto.IsActive;
                }

                context.Update(room);
                int affectedRows = await context.SaveChangesAsync();
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

        public async Task<int> DeleteRoom(int id)
        {
            try
            {
                var room = await context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
                if (room != null)
                {
                    room.IsActive = false;
                    context.Update(room);
                    var affectedRows = await context.SaveChangesAsync();
                    return affectedRows;
                }

                throw new KeyNotFoundException($"Room with ID {id} not found.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion

    }

}
