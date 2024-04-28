using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.WeddingHall
{
    public class WeddingHallRecordDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
        public City City { get; set; }
    }
}
