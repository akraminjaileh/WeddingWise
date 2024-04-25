using WeddingWise_Core.Models.Entities;
using System.Linq.Expressions;
namespace WeddingWise_Core.IRepos
{
    public interface IAdminRepos
    {
        //Employee Management
        Task<List<User>> FindAllUser();
        
        //Client Management


        //Agent Management


        //CarRental Management


        //Reservation Management


        //Room Management


        //WeddingHall Management



    }
}
