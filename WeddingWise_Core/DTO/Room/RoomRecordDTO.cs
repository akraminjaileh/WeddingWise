using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingWise_Core.DTO.Room
{
    public class RoomRecordDTO
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string Image { get; set; }
        public float StartPrice { get; set; }
    }
}
