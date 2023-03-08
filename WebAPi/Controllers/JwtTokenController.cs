using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPi.InterfaceFunction;
using WebAPi.Modal;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController : ControllerBase
    {

        private readonly JwtAuthenticationManager JwtInterface;

        public JwtTokenController(JwtAuthenticationManager jwtInterface)
        {
            JwtInterface = jwtInterface;
        }

        [HttpPost]
        public IActionResult AuthenticationTokenData([FromBody] UserTable usedata)
        {
            var token = JwtInterface.Authentication(usedata.UserName, usedata.PassWord);

            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
