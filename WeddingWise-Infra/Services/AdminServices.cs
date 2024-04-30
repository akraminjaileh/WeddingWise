using Microsoft.EntityFrameworkCore;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Infra.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepos repos;

        public AdminServices(IAdminRepos repos) => this.repos = repos;


        #region User Management
        public async Task<int> CreateUser(CreateOrUpdateUserDTO dto, bool IsAdminOrEmployee)
        {
            int affectedRows = await repos.CreateUser(dto , IsAdminOrEmployee);

            return affectedRows;
        }

        public async Task<int> UpdateUser(CreateOrUpdateUserDTO dto, int id, bool IsAdmin)
        {
            int affectedRows = await repos.UpdateUser(dto, id, IsAdmin);

            return affectedRows;
        }


        public async Task<int> DeleteUser(int id)
        {
            int affectedRows = await repos.DeleteUser(id);

            return affectedRows;
        }

#endregion


        #region CarRental Management
        public async Task<int> CreateCar(CreateOrUpdateCarDTO dto)
        {
            return await repos.CreateCar(dto);
        }


        public async Task<int> UpdateCar(CreateOrUpdateCarDTO dto, int id, bool IsAdmin)
        {
            return await repos.UpdateCar(dto, id, IsAdmin);
        }


        public async Task<int> DeleteCar(int id)
        {
            return await repos.DeleteCar(id);
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
