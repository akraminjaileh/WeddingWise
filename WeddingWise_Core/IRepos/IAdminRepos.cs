using WeddingWise_Core.Models.Entities;
namespace WeddingWise_Core.IRepos
{
    public interface IAdminRepos
    {


        void AddToDb(object obj);
        void UpdateOnDb(object obj);
        Task<int> SaveChangesAsync();

        //Get Agent Id for Create Car or Wedding
        Task<int> GetAgentId(int AgentId);


        //CarRental Management

        Task<CarRental> UpdateCar(int id);
        Task<CarRental> DeleteCar(int id);


        //WeddingHall Management

        Task<WeddingHall> UpdateWeddingHall(int id);
        Task<WeddingHall> DeleteWeddingHall(int id);


        //Room Management
        Task<Room> UpdateRoom(int id);
        Task<Room> DeleteRoom(int id);



    }
}
