using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.DTO.Room;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.AgentTransaction
{
    public class AgentTransactionDetailsDTO
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
        public TransactionType TransactionType { get; set; }
        public float Amount { get; set; }
        public float Fees { get; set; }
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }
        public ReservationCarDTO ReservationCar { get; set; }
        public ReservationWeddingHallWithRoomDTO ReservationWedding { get; set; }
        public RoomRecordDTO Room {  get; set; }
    }
}
