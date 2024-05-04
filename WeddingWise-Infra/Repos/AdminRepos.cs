using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
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


        #region Effected on databases

        public void AddToDb(object obj)
        {
            context.Add(obj);
        }
        public void UpdateOnDb(object obj)
        {
            context.Update(obj);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        #endregion


        #region CarRental Management

        public async Task<int> CreateCar(int AgentId)
        {
            var agent = await context.Users.FindAsync(AgentId);
            if (agent == null)
            {
                throw new KeyNotFoundException($"Agent with ID {AgentId} not found.");
            }

            return agent.Id;
        }

        public async Task<CarRental> UpdateCar(int id)
        {
            var car = await context.CarRentals.FirstOrDefaultAsync(x => x.Id == id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }

            return car;
        }



        public async Task<CarRental> DeleteCar(int id)
        {

            var car = await context.CarRentals.FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {id} not found.");
            }

            return car;
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
