using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class AgentTransaction : ParentEntity
    {
        public float TotalAmount { get; set; }  //Amount - fees
        public TransactionType TransactionType { get; set; } //Income or Outcome
        public float Amount { get; set; } //AgentTransaction Amount 
        public float Fees { get; set; } //Application Percentage Fees
        public Status Status { get; set; } //Transaction Status (Pending  or Completed)

        public virtual User Agent { get; set; }

    }
}
