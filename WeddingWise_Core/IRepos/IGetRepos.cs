using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;

namespace WeddingWise_Core.IRepos
{
    public interface IGetRepos
    {
        Task<IEnumerable<UserRecordDTO>> GetAllUser();
        Task<UserDetailsDTO> GetOneUserDetails(int id , bool IsAdmin);
        Task<IEnumerable<CarRentalRecordDTO>> GetAllCar();
        Task<CarRentalDetailsDTO> GetCarsDetails(int id , bool IsAdminOrEmployee);
        Task<IEnumerable<WeddingHallRecordDTO>> GetAllWedding();
        Task<WeddingHallDetailsDTO> GetWeddingDetails(int id, bool IsAdminOrEmployee);
        Task<RoomDetailsDTO> GetRoomDetails(int id, bool IsAdminOrEmployee);
    }
}
