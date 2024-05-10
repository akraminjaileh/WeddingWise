using Microsoft.AspNetCore.Mvc;
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

    }
}
