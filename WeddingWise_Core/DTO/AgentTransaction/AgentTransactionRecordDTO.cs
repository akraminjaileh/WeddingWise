using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise_Core.DTO.AgentTransaction
{
    public class AgentTransactionRecordDTO
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; } 
        public decimal Fees { get; set; } 
        public Status Status { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
