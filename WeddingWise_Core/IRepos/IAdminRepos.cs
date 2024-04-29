using WeddingWise_Core.DTO.User;
namespace WeddingWise_Core.IRepos
{
    public interface IAdminRepos
    {
        //User Management
        Task<int> CreateUser(CreateOrUpdateUserDTO user);
        Task<int> UpdateUser(CreateOrUpdateUserDTO user ,int id , bool IsAdmin);
        Task<int> DeleteUser(int id);


        //CarRental Management


        //Reservation Management


        //Room Management


        //WeddingHall Management



    }
}
