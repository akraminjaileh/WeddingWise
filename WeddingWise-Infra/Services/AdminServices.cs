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
