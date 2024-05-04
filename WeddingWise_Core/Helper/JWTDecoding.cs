using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WeddingWise_Core.Helper
{
    public static class JWTDecoding
    {
        public async static Task<JwtPayload> JWTDecod(string token)
        {

            string tokenBearer = "Bearer " + token;

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("Invalid Token Format");
            }

            var jwtEncodedString = tokenBearer.Substring(7); // Skip "Bearer "

            try
            {
                var tokendec = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);

                if (tokendec.ValidTo <= DateTime.UtcNow)
                {
                    throw new SecurityTokenExpiredException("Token has expired");
                }

                return tokendec.Payload;
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Token decoding failed", ex);
            }
        }
    }
}
