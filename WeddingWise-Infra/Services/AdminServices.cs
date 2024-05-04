using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepos repos;

        public AdminServices(IAdminRepos repos) => this.repos = repos;


        #region CarRental Management

        public async Task<int> CreateCar(CreateOrUpdateCarDTO dto, JwtPayload token)
        {
            try
            {
                if (!token.Claims.Any())
                {
                    throw new KeyNotFoundException($"User with ID not found.");
                }

                int userId = int.Parse(token.ElementAt(0).Value.ToString());

                string userType = token.ElementAt(1).Value.ToString();

                if (!userType.Equals(UserType.Admin) || !userType.Equals(UserType.Employee))
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

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
                    PricePerHour = dto.PricePerHour.Value,

                };

                car.User.Id = userId;

                if (dto.AgentId <= 0)
                {
                    throw new KeyNotFoundException($"Agent with ID {dto.AgentId} not found.");
                }

                int agent = await repos.CreateCar(dto.AgentId);
                car.Agent.Id = agent;

                repos.AddToDb(car);

                int affectedRows = await repos.SaveChangesAsync();
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



        public async Task<int> UpdateCar(CreateOrUpdateCarDTO dto, int id, string token)
        {
            try
            {
                if (token.Equals(UserType.Admin.ToString()) || token.Equals(UserType.Employee.ToString()) || token.Equals(UserType.Agent.ToString()))
                {
                    throw new UnauthorizedAccessException("User does not have sufficient permissions.");

                }

                var car = await repos.UpdateCar(id);

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

                if (token.Equals(UserType.Admin.ToString()) || token.Equals(UserType.Employee.ToString()))
                {
                    car.Year = dto.Year ?? car.Year;
                    car.LicensePlate = dto.LicensePlate ?? car.LicensePlate;
                    car.IsActive = dto.IsActive;
                }

                repos.AddToDb(car);
                int affectedRows = await repos.SaveChangesAsync();
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
                var car = await repos.DeleteCar(id);

                car.IsActive = false;
                repos.UpdateOnDb(car);
                var affectedRows = await repos.SaveChangesAsync();
                return affectedRows;
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
            return await repos.CreateWeddingHall(dto);
        }

        public async Task<int> UpdateWeddingHall(CreateOrUpdateWeddingHallDTO dto, int id, bool IsAdmin)
        {
            return await repos.UpdateWeddingHall(dto, id, IsAdmin);
        }

        public async Task<int> DeleteWeddingHall(int id)
        {
            return await repos.DeleteWeddingHall(id);
        }

        #endregion


        #region Room Management
        public async Task<int> CreateRoom(CreateOrUpdateRoom dto)
        {
            return await repos.CreateRoom(dto);
        }

        public async Task<int> UpdateRoom(CreateOrUpdateRoom dto, int id, bool IsAdmin)
        {
            return await repos.UpdateRoom(dto, id, IsAdmin);
        }

        public async Task<int> DeleteRoom(int id)
        {
            return await repos.DeleteRoom(id);
        }

        #endregion

    }
}
