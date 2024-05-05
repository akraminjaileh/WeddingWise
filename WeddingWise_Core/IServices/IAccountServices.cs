using System.IdentityModel.Tokens.Jwt;
using WeddingWise_Core.DTO.Account;

namespace WeddingWise_Core.IServices
{
    public interface IAccountServices
    {
        //Account Management
        Task<int> Registration(RegistrationDTO dto);
        Task<string> Login(LoginDTO dto);
        // Task Logout(string refreshToken);
        Task<int> UpdateProfile(UpdateProfileDTO dto, JwtPayload token,int id);
        Task<int> DisableAccount(int id, string userType);


    }
}
