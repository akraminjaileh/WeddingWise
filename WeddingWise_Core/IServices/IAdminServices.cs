using WeddingWise_Core.DTO;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.IServices
{
    public interface IAdminServices
    {
        //User Management
        Task CreateUser(object user);
        Task UpdateUser(object user);
        Task DeleteUser(int id);


        //CarRental Management


        //Reservation Management


        //Room Management


        //WeddingHall Management
    }
}
