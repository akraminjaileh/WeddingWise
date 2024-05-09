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

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllTransaction([FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetAllTransaction(claims));
        }



    }
}
