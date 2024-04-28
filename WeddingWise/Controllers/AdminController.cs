using Microsoft.AspNetCore.Mvc;
using WeddingWise_Core.IServices;
using static WeddingWise_Core.Enums.WeddingWiseLookups;

namespace WeddingWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices services;
        private readonly IGetServices getServices;

        public AdminController(IAdminServices services, IGetServices getServices)
        {
            this.services = services;
            this.getServices = getServices;
        }


        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await getServices.GetAllUser(default));
        }
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await getServices.GetAllUser(UserType.Employee));
        }
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllAgent()
        {
            return Ok(await getServices.GetAllUser(UserType.Agent));
        }
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllClient()
        {
            return Ok(await getServices.GetAllUser(UserType.Client));
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneUser(int id)
        {
            return Ok(await getServices.GetOneUserDetails(id,true));
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllCar()
        {
            return Ok(await getServices.GetAllCar());
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneCar(int id)
        {
            return Ok(await getServices.GetCarsDetails(id,true));
        }

    }
}
