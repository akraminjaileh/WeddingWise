using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWise_Core.IServices
{
    public interface IClientServices
    {
        //Open Reservation Container
        Task<int> OpenNewReservation(int id);
       // Task CloseReservation();

    }
}
