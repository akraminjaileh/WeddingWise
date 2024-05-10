using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IGetServices
    {
        Task<IEnumerable<UserRecordDTO>> GetAllUser(JwtPayload payload);
        Task<UserDetailsDTO> GetOneUserDetails(int id, JwtPayload payload);
        Task<IEnumerable<CarRentalRecordDTO>> GetAllCar();
        Task<CarRentalDetailsDTO> GetCarsDetails(int id, JwtPayload payload);
        Task<IEnumerable<WeddingHallRecordDTO>> GetAllWedding();
        Task<WeddingHallDetailsDTO> GetWeddingDetails(int id, JwtPayload payload);
        Task<RoomDetailsDTO> GetRoomDetails(int id, JwtPayload payload);
    }
}
