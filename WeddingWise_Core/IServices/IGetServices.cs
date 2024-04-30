using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.IServices
{
    public interface IGetServices
    {
        Task<IEnumerable<object>> GetAllUser(UserType userType);
        Task<object> GetOneUserDetails(int id , bool IsAdmin);
        Task<IEnumerable<object>> GetAllCar();
        Task<object> GetCarsDetails(int id , bool IsAdminOrEmployee);
        Task<IEnumerable<object>> GetAllWedding();
        Task<object> GetWeddingDetails(int id, bool IsAdminOrEmployee);
        Task<object> GetRoomDetails(int id, bool IsAdminOrEmployee);
    }
}
