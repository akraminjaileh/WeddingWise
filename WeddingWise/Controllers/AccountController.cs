using Microsoft.AspNetCore.Mvc;
using WeddingWise_Core.DTO.Account;
using WeddingWise_Core.Helper;
using WeddingWise_Core.IServices;

namespace WeddingWise.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices services;
        private readonly ILogger<AccountController> logger;

        public AccountController(IAccountServices services, ILogger<AccountController> logger)
        {
            this.services = services;
            this.logger = logger;
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Registration(RegistrationDTO dto)
        {

            var affectedRows = await services.Registration(dto);
            return Ok(affectedRows);
        }

        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Login([FromForm]LoginDTO dto)
        {

            var affectedRows = await services.Login(dto);
            return Ok(affectedRows);
        }


        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDTO dto, [FromHeader] string token,int id)
        {
            var claims = await JWTDecoding.JWTDecod(token);

            var affectedRows = await services.UpdateProfile(dto, claims,id);
            return Ok(affectedRows);

        }


        [HttpDelete]
        [Route("[Action]")]
        public async Task<IActionResult> DisableAccount(int id, [FromHeader] string token)
        {
            var claims = await JWTDecoding.JWTDecod(token);

            var userType = claims.ElementAt(1).Value.ToString();

            var affectedRows = await services.DisableAccount(id, userType);
            return Ok(affectedRows);


        }
    }
}
