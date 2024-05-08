using Microsoft.AspNetCore.Mvc;
using WeddingWise_Core.DTO.ReservationCar;
using WeddingWise_Core.DTO.ReservationWeddingHall;
using WeddingWise_Core.Helper;
using WeddingWise_Core.IServices;

namespace WeddingWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices services;
        private readonly ILogger<ClientController> logger;

        public ClientController(IClientServices services, ILogger<ClientController> logger)
        {
            this.services = services;
            this.logger = logger;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetReservationHistory([FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetReservationHistory(payload));
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetReservationDetails(int id,[FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetReservationDetails(id,payload));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> RemoveCarFromReservation(int reservationId, int reservationCarId, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.RemoveCarFromReservation(reservationId,reservationCarId, payload));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> RemoveWeddingRoomFromReservation(int reservationId, int reservationWeddingId, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.RemoveWeddingRoomFromReservation(reservationId,reservationWeddingId, payload));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> Checkout(int reservationId, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);

            return Ok(await services.Checkout( payload));
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> AddCarInReservation(ReservationCarDTO dto, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.AddCarInReservation(dto , payload));
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> AddWeddingRoomInReservation([FromForm]ReservationWeddingHallWithRoomDTO dto, [FromHeader] string token)
        {
            var payload = await JWTDecoding.JWTDecod(token);
            return Ok(await services.AddWeddingRoomInReservation(dto, payload));
        }

    }

}
