using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WeddingWise_Core.Helper;
using WeddingWise_Core.IServices;

namespace WeddingWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly IGetServices services;
        private readonly ILogger<SharedController> logger;

        public SharedController(IGetServices services, ILogger<SharedController> logger)
        {
            this.services = services;
            this.logger = logger;
        }


        //For Admin and Employee
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllUser([FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetAllUser(payload));
        }

        //For Admin and Employee
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneUser(int id, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetOneUserDetails(id, payload));
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllCar()
        {
            return Ok(await services.GetAllCar());
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneCar(int id, [FromHeader] string? token)
        {
            if (token.IsNullOrEmpty())
            {
                return Ok(await services.GetCarsDetails(id, null));
            }
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetCarsDetails(id, payload));
        }



        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllWedding()
        {
            return Ok(await services.GetAllWedding());
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneWedding(int id, [FromHeader] string? token)
        {
            if (token.IsNullOrEmpty())
            {
                return Ok(await services.GetWeddingDetails(id, null));
            }
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetWeddingDetails(id, payload));
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneRoom(int id, [FromHeader] string? token)
        {
            if (token.IsNullOrEmpty())
            {
                return Ok(await services.GetRoomDetails(id, null));
            }
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetRoomDetails(id, payload));
        }

    }
}
