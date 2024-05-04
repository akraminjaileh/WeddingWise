using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.Models.Entities;
namespace WeddingWise_Core.IRepos
{
    public interface IAdminRepos
    {


        void AddToDb(object obj);
        void UpdateOnDb(object obj);
        Task<int> SaveChangesAsync();
      


        //CarRental Management

        Task<int> CreateCar(int AgentId);
        Task<CarRental> UpdateCar(int id);
        Task<CarRental> DeleteCar(int id);


        //WeddingHall Management
        Task<int> CreateWeddingHall(CreateOrUpdateWeddingHallDTO dto);
        Task<int> UpdateWeddingHall(CreateOrUpdateWeddingHallDTO dto, int id, bool IsAdmin);
        Task<int> DeleteWeddingHall(int id);


        //Room Management
        Task<int> CreateRoom(CreateOrUpdateRoom dto);
        Task<int> UpdateRoom(CreateOrUpdateRoom dto, int id, bool IsAdmin);
        Task<int> DeleteRoom(int id);



    }
}
