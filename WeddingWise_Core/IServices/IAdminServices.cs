using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IAdminServices
    {
       
        //CarRental Management
        Task<int> CreateCar(CreateOrUpdateCarDTO dto);
        Task<int> UpdateCar(CreateOrUpdateCarDTO dto, int id, bool IsAdmin);
        Task<int> DeleteCar(int id);


        //WeddingHall Management
        Task<int> CreateWeddingHall(CreateOrUpdateWeddingHallDTO dto);
        Task<int> UpdateWeddingHall(CreateOrUpdateWeddingHallDTO dto, int id, bool IsAdmin);
        Task<int> DeleteWeddingHall(int id);


        //Room Management
        Task<int> CreateRoom(CreateOrUpdateRoom dto);
        Task<int> UpdateRoom(CreateOrUpdateRoom dto, int id, bool IsAdmin);
        Task<int> DeleteRoom(int id);

        //Reservation Management
    }
}
