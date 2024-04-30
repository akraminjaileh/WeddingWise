using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IRepos
{
    public interface IClientRepos
    {
        Task<User> OpenNewReservation(int id);
        Task<int> SaveChangesAsync();
        void AddToDb(object obj);

        //Task AddCarInReservation(int id);
        //Task AddWeddingInReservation(int id);
    }
}
