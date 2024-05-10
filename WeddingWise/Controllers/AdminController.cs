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
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices services;
        private readonly ILogger<AdminController> logger;

        public AdminController(IAdminServices services, ILogger<AdminController> logger)
        {
            this.services = services;
            this.logger = logger;
        }



        #region Car Management


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateCar(CreateOrUpdateCarDTO dto, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.CreateCar(dto, payload));
        }



        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteCar(int id, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.DeleteCar(id, payload));
        }

        #endregion


        #region Wedding Management

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateWedding(CreateOrUpdateWeddingHallDTO dto, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.CreateWeddingHall(dto, payload));
        }



        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteWedding(int id, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.DeleteWeddingHall(id, payload));
        }

        #endregion


        #region Room Management



        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateRoom(CreateOrUpdateRoom dto, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.CreateRoom(dto, payload));
        }


        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteRoom(int id, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.DeleteRoom(id, payload));
        }

        #endregion

    }
}
