using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IServices
{
    public interface IAdminServices
    {
        Task<List<User>> FindAllUser();
    }
}
