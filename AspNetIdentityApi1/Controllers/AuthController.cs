using AspNetIdentityApi1.Services;
using AspNetIdentityShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspNetIdentityApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private IMailService _mailService;

        public AuthController(IUserService userService,IMailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }

        //  /api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result= await _userService.RegisterUserAsync(model);
                if(result.IsSuccess)
                    return Ok(result); //Status Code: 200
                else
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid");  //Status Code: 400
        }


        //   /api/auth/login
        [HttpPost("Login")]

        public async Task<IActionResult> LoginAync([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result=await _userService.LoginUserAsync(model);
                if (result.IsSuccess)
                {
                    await _mailService.SendEmailAsync(model.Email,"New Login", "<h1>Hey!, new login to your account noticed</h1><p>New Login to your account at " + DateTime.Now +" </p>");
                    return Ok(result);
                }
                    

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        private object SendEmailAsync(string email, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
