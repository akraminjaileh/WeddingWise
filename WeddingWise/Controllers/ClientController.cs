using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingWise_Core.IServices;

namespace WeddingWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices services;

        public ClientController(IClientServices services)
        {
            this.services = services;
        }


        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> OpenNewReservation(int id)
        {
           return Ok( await services.OpenNewReservation(id));
        }

    }

}
