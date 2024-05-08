using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IGetRepos
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetOneUserDetails(int id);
        Task<IEnumerable<CarRental>> GetAllCar();
        Task<CarRental> GetCarsDetails(int id);
        Task<IEnumerable<WeddingHall>> GetAllWedding();
        Task<WeddingHall> GetWeddingDetails(int id);
        Task<Room> GetRoomDetails(int id);
    }
}
