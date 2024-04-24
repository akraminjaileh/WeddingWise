using WeddingWise_Core.Models.Shared;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.Models.Entities
{
    public class AgentTransaction : ParentEntity
    {
        public decimal Balance { get; set; }  //Total Balance (Available and Pending)
        public TransactionType TransactionType { get; set; } //Income or Outcome
        public decimal Amount { get; set; } //Transaction Amount 
        public decimal Fees { get; set; } //Application Percentage Fees
        public Status Status { get; set; } //Transaction Status (Pending  or Completed)

        public virtual User User { get; set; }

    }
}
