using Microsoft.AspNetCore.Mvc;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.WeddingHall;
using WeddingWise_Core.Helper;
using WeddingWise_Core.IServices;

namespace WeddingWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentServices services;

        public AgentController(IAgentServices services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllTransaction([FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetAllTransaction(payload));
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetTransactionDetails([FromHeader] string token , int agentTransactionId)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetTransactionDetails(payload, agentTransactionId));
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> CheckBalance([FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.CheckBalance(payload));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateCar(CreateOrUpdateCarDTO dto, int carId, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.UpdateCar(dto, carId, payload));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateWedding(CreateOrUpdateWeddingHallDTO dto, int weddingId, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.UpdateWeddingHall(dto, weddingId, payload));
        }


        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateRoom(CreateOrUpdateRoom dto, int roomId, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.UpdateRoom(dto, roomId, payload));
        }

    }
}
