﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingWise_Core.DTO.AgentTransaction;

namespace WeddingWise_Core.IServices
{
    public interface IAgentServices
    {
        Task<IEnumerable<AgentTransactionRecordDTO>> GetAllTransaction(JwtPayload token);
    }
}
