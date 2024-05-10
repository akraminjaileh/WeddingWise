using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IDbRepos;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Infra.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepos repos;
        private readonly IDbRepos dbRepos;

        public AdminServices(IAdminRepos repos, IDbRepos dbRepos)
        {
            this.repos = repos;
            this.dbRepos = dbRepos;
        }


        #region CarRental Management

        public async Task<int> CreateCar(CreateOrUpdateCarDTO dto, JwtPayload payload)
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

                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
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
                        PricePerHour = dto.PricePerHour.Value,

                    };

                    car.User = await repos.GetUserId(userId);

                    car.Agent = await repos.GetUserId(dto.AgentId);

                    dbRepos.AddToDb(car);

                    int affectedRows = await dbRepos.SaveChangesAsync();
                    return affectedRows;
                }
                throw new UnauthorizedAccessException("User does not have sufficient permissions.");
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



        public async Task<int> DeleteCar(int id, JwtPayload payload)
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


                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
                {




                    var car = await repos.DeleteCar(id);

                    car.IsActive = false;
                    dbRepos.UpdateOnDb(car);
                    var affectedRows = await dbRepos.SaveChangesAsync();
                    return affectedRows;
                }
                throw new UnauthorizedAccessException("User does not have sufficient permissions.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


        #region WeddingHall Management
        public async Task<int> CreateWeddingHall(CreateOrUpdateWeddingHallDTO dto, JwtPayload payload)
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


                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
                {

                    var wedding = new WeddingHall
                    {
                        Title = dto.Title,
                        City = dto.City.Value,
                        Address = dto.Address,
                    };

                    wedding.User = await repos.GetUserId(userId);
                    wedding.Agent = await repos.GetUserId(dto.AgentId);

                    dbRepos.AddToDb(wedding);
                    int affectedRows = await dbRepos.SaveChangesAsync();
                    return affectedRows;
                }
                throw new UnauthorizedAccessException("User does not have sufficient permissions.");
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



        public async Task<int> DeleteWeddingHall(int id, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                var userType = payload["UserType"].ToString();


                if (!userType.Equals(UserType.Admin.ToString()) || !userType.Equals(UserType.Employee.ToString()))
                {

                    var wedding = await repos.DeleteWeddingHall(id);

                    wedding.IsActive = false;
                    dbRepos.UpdateOnDb(wedding);
                    var affectedRows = await dbRepos.SaveChangesAsync();
                    return affectedRows;
                }
                throw new UnauthorizedAccessException("User does not have sufficient permissions.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


        #region Room Management
        public async Task<int> CreateRoom(CreateOrUpdateRoom dto, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                var userType = payload["UserType"].ToString();

                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
                {

                    var room = new Room
                    {
                        RoomName = dto.RoomName,
                        SeatsNumber = dto.SeatsNumber,
                        Floor = dto.Floor,
                        StartPrice = dto.StartPrice.Value,
                    };
                    room.WeddingHall.Id = dto.WeddingHallId;


                    dbRepos.AddToDb(room);
                    int affectedRows = await dbRepos.SaveChangesAsync();
                    return affectedRows;
                }
                throw new UnauthorizedAccessException("User does not have sufficient permissions.");
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



        public async Task<int> DeleteRoom(int id, JwtPayload payload)
        {
            try
            {
                if (!payload.Claims.Any())
                {
                    throw new UnauthorizedAccessException("Invalid Token Claims");
                }

                var userType = payload["UserType"].ToString();


                if (userType.Equals(UserType.Admin.ToString()) || userType.Equals(UserType.Employee.ToString()))
                {


                    var room = await repos.DeleteRoom(id);

                    room.IsActive = false;
                    dbRepos.UpdateOnDb(room);
                    var affectedRows = await dbRepos.SaveChangesAsync();
                    return affectedRows;

                }
                throw new UnauthorizedAccessException("User does not have sufficient permissions.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        #endregion


    }
}
