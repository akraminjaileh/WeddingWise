﻿using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.AgentTransaction;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise_Core.IServices
{
    public interface IAgentServices
    {


        #region Transaction Assist

        Task IncomeAgentAmount(Reservation reservation); // when client make a checkout amount transfer with status pending 101

        Task UpdateTransactionStatus(); // Hangfire > when endTime<=DateTimeNow > update status with available 106

        #endregion


        #region Transaction Action

        Task<IEnumerable<AgentTransactionRecordDTO>> GetAllTransaction(JwtPayload payload);
        Task<AgentTransactionDetailsDTO> GetTransactionDetails(JwtPayload payload, int agentTransactionId);
        Task<CheckBalanceDTO> CheckBalance(JwtPayload payload);
        Task<int> UpdateWeddingHall(CreateOrUpdateWeddingHallDTO dto, int weddingId, JwtPayload payload);

        Task<int> UpdateRoom(CreateOrUpdateRoom dto, int roomId, JwtPayload payload);

        Task<int> UpdateCar(CreateOrUpdateCarDTO dto, int carId, JwtPayload payload);

        #endregion


    }
}
