using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> CreateCar(CreateOrUpdateCarDTO dto)
        {
            return Ok(await services.CreateCar(dto));
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateCar(CreateOrUpdateCarDTO dto, int id)
        {
            return Ok(await services.UpdateCar(dto, id, true));
        }

        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            return Ok(await services.DeleteCar(id));
        }

        #endregion


        #region Wedding Management
      
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
