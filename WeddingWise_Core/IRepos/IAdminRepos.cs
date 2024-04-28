using WeddingWise_Core.DTO.User;
namespace WeddingWise_Core.IRepos
{
    public interface IAdminRepos
    {
        //User Management
        Task CreateUser(CreateUserDTO user);
        Task UpdateUser(UpdateUserDTO user);
        Task DeleteUser(int id);


        //CarRental Management


        //Reservation Management


        //Room Management


        //WeddingHall Management



    }
}
