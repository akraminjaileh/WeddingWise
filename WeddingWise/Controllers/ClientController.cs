using Microsoft.AspNetCore.Mvc;
using WeddingWise_Core.DTO.ReservationWeddingHall;
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


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> OpenNewReservation(int id)
        {
            return Ok(await services.OpenNewReservation(id));
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> AddOrUpdateCarInReservation(DateTime StartTime, DateTime EndTime, int CarRentalId, int ClientId)
        {
            return Ok(await services.AddOrUpdateCarInReservation(StartTime, EndTime, CarRentalId, ClientId));
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> AddOrUpdateWeddingRoomInReservation(ReservationWeddingHallWithRoomDTO dto)
        {
            return Ok(await services.AddOrUpdateWeddingRoomInReservation(dto));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateReservationPrice(int id)
        {
            await services.UpdateReservationPrice(id);
            return Ok();
        }
    }

}
