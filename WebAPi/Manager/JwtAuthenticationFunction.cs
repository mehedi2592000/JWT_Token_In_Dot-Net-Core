using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPi.InterfaceFunction;

namespace WebAPi.Manager
{
    public class JwtAuthenticationFunction : JwtAuthenticationManager
    {


        public readonly string key;

        public JwtAuthenticationFunction(string key)
        {
            this.key = key;
        }

        public readonly IDictionary<string, string> Users = new Dictionary<string, string> { { "test1", "pass1" }, { "test2", "pass2" } };

        public string Authentication(string username, string password)
        {
            if (!Users.Any(u => u.Key == username && u.Value==password))
            {
                return null;
            }

            var tokenHandle = new JwtSecurityTokenHandler();
            var tokenKey=Encoding.ASCII.GetBytes(key);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, password)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(

                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            var token = tokenHandle.CreateToken(tokenDescription);
            return tokenHandle.WriteToken
        }
    }
}
