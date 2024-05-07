using Microsoft.AspNetCore.Mvc;
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
            var claims = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetReservationHistory(claims));
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetReservationDetails(int id,[FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);

            return Ok(await services.GetReservationDetails(id,claims));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> RemoveCarFromReservation(int reservationId, int reservationCarId, [FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);
            var userType = claims.ElementAt(1).Value.ToString();

            return Ok(await services.RemoveCarFromReservation(reservationId,reservationCarId, userType));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> RemoveWeddingRoomFromReservation(int reservationId, int reservationWeddingId, [FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);
            var userType = claims.ElementAt(1).Value.ToString();

            return Ok(await services.RemoveWeddingRoomFromReservation(reservationId,reservationWeddingId, userType));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> Checkout(int id, [FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);

            return Ok(await services.Checkout(id, claims));
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> AddCarInReservation(DateTime StartTime, DateTime EndTime, int CarRentalId, int ClientId, [FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);
            var userType = claims.ElementAt(1).Value.ToString();
            return Ok(await services.AddCarInReservation(StartTime, EndTime, CarRentalId, ClientId, userType));
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> AddWeddingRoomInReservation([FromForm]ReservationWeddingHallWithRoomDTO dto, [FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);
            var userType = claims.ElementAt(1).Value.ToString();
            return Ok(await services.AddWeddingRoomInReservation(dto, userType));
        }

    }

}
