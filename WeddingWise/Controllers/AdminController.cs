using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WeddingWise_Core.DTO.User;
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

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> CreateUser(CreateOrUpdateUserDTO dto)
        {


            var affectedRows = await services.CreateUser(dto);
            return Ok(affectedRows);
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateUser(CreateOrUpdateUserDTO dto, int id)
        {
            try
            {

                var affectedRows = await services.UpdateUser(dto, id, true);
                if (affectedRows > 0)
                    return Ok(affectedRows);
                else
                    return NotFound("No user was updated, user not found.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the user.");
            }
        }

        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var affectedRows = await services.DeleteUser(id);
            return Ok(affectedRows);
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

        #endregion


    }
}
