using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WeddingWise_Core.DTO.CarRental;
using WeddingWise_Core.DTO.Room;
using WeddingWise_Core.DTO.User;
using WeddingWise_Core.DTO.WeddingHall;
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
        private readonly ILogger<AdminController> logger;

        public AdminController(IAdminServices services, IGetServices getServices, ILogger<AdminController> logger)
        {
            this.services = services;
            this.getServices = getServices;
            this.logger = logger;
        }

        #region User Management
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await getServices.GetAllUser(default));
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneUser(int id)
        {
            return Ok(await getServices.GetOneUserDetails(id, true));
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

        

        #endregion


        #region Car Management
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

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateCar(CreateOrUpdateCarDTO dto)
        {
            return Ok(await services.CreateCar(dto));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateCar(CreateOrUpdateCarDTO dto,int id)
        {
            return Ok(await services.UpdateCar(dto,id, true));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            return Ok(await services.DeleteCar(id));
        }

        #endregion


        #region Wedding Management
        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetAllWedding()
        {
            return Ok(await getServices.GetAllWedding());
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneWedding(int id)
        {
            return Ok(await getServices.GetWeddingDetails(id, true));
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateWedding(CreateOrUpdateWeddingHallDTO dto)
        {
            return Ok(await services.CreateWeddingHall(dto));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateWedding(CreateOrUpdateWeddingHallDTO dto, int id)
        {
            return Ok(await services.UpdateWeddingHall(dto, id, true));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteWedding(int id)
        {
            return Ok(await services.DeleteWeddingHall(id));
        }

        #endregion


        #region Room Management
      

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetOneRoom(int id)
        {
            return Ok(await getServices.GetRoomDetails(id, true));
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateRoom(CreateOrUpdateRoom dto)
        {
            return Ok(await services.CreateRoom(dto));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateRoom(CreateOrUpdateRoom dto, int id)
        {
            return Ok(await services.UpdateRoom(dto, id, true));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            return Ok(await services.DeleteRoom(id));
        }

        #endregion

    }
}
