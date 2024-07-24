using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.API.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username);
    }

    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly string _secret = "ad64766cc06b1055f89eef4b828af2ec77d914af8f813723389fd736703ab02403799fa21820870261039f3c29b52e8266b31d603cac1e7aa75bd7b2cf41c30605b7344fdcb220427c5849f4ad21c6ba198bed1b6bdee7f37dfb3a2ba40251ba3027e78eb838bd82aa326123061e9c5a1b6bf284de30dddbea38c5136a8a753d7407f7352c33f9cbaed214a045cbd12eb960fd5ec6d0ca81bf4f8b9b9d79d8cbd147f7396e26002482b058d6a6bb4e3d8181a5e8c4d9dec416e3d8f5c3f0c3985a4225aa7d9d0dd1d46e517cdf0f6953c0fc2ec695caf3fde724094fe2896c900f96c6bce7c2b6830b51d04876f08e780b3538b066d1fd65838083867ad0a254";
        private readonly string _issuer = "https://localhost:5002";
        private readonly string _audience = "youraudience";

        public string GenerateToken(string username)
        {
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Name, "Erfan"),
            new Claim("role", "Admin"),
            new Claim("scope", "Catalog.API")
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity( new[] 
                {
                    new Claim(ClaimTypes.Name, username), 
                    new Claim(JwtRegisteredClaimNames.Name, "Erfan"),
                    new Claim("role", "Admin"),
                    new Claim("scope", "Catalog.API")} 
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
