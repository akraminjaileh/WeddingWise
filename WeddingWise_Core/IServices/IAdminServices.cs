using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IAdminServices
    {

        //CarRental Management
        Task<int> CreateCar(CreateOrUpdateCarDTO dto, JwtPayload payload);

        Task<int> DeleteCar(int id, JwtPayload payload);


        //WeddingHall Management
        Task<int> CreateWeddingHall(CreateOrUpdateWeddingHallDTO dto, JwtPayload payload);
 
        Task<int> DeleteWeddingHall(int id, JwtPayload payload);

        //Room Management
        Task<int> CreateRoom(CreateOrUpdateRoom dto, JwtPayload payload);
    
        Task<int> DeleteRoom(int id, JwtPayload payload);

    }
}
