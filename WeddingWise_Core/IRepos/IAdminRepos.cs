using WeddingWise_Core.Models.Entities;
namespace WeddingWise_Core.IRepos
{
    public interface IAdminRepos
    {


        //Get User Id for Create Car or Wedding
        Task<User> GetUserId(int Id);


        //CarRental Management

       
        Task<CarRental> DeleteCar(int id);


        //WeddingHall Management

       
        Task<WeddingHall> DeleteWeddingHall(int id);


        //Room Management
        
        Task<Room> DeleteRoom(int id);



    }
}
