using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;

namespace WeddingWise_Core.IServices
{
    public interface IAdminServices
    {

        //CarRental Management
        Task<int> CreateCar(CreateOrUpdateCarDTO dto, JwtPayload token);

        Task<int> DeleteCar(int id, string token);


        //WeddingHall Management
        Task<int> CreateWeddingHall(CreateOrUpdateWeddingHallDTO dto, JwtPayload token);
 
        Task<int> DeleteWeddingHall(int id, string token);

        //Room Management
        Task<int> CreateRoom(CreateOrUpdateRoom dto, JwtPayload token);
    
        Task<int> DeleteRoom(int id, string token);

    }
}
