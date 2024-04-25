using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingWise_Core.IRepos;
using WeddingWise_Core.IServices;
using WeddingWise_Core.Models.Entities;

namespace WeddingWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices services;

        public AdminController(IAdminServices services)
        {
            this.services = services;
        }

        [HttpGet]
        [Route("[Action]")]
        public async Task<IActionResult> GetUser()
        {
            var result= await services.FindAllUser();
            return Ok(result);
        }

    }
}
