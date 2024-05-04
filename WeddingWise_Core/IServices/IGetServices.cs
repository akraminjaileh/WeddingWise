using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IGetServices
    {
        Task<IEnumerable<UserRecordDTO>> GetAllUser(string token);
        Task<UserDetailsDTO> GetOneUserDetails(int id, string token);
        Task<IEnumerable<CarRentalRecordDTO>> GetAllCar();
        Task<CarRentalDetailsDTO> GetCarsDetails(int id, string token);
        Task<IEnumerable<WeddingHallRecordDTO>> GetAllWedding();
        Task<WeddingHallDetailsDTO> GetWeddingDetails(int id, string token);
        Task<RoomDetailsDTO> GetRoomDetails(int id, string token);
    }
}
