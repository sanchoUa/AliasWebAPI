using AliasWebAPI.InternalServices;
using AliasWebAPI.LL;
using AliasWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using Unity;

namespace AliasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthLL _authLL;

        public AuthController(IAuthLL authLL)
        {
            _authLL = authLL;
        }

        [HttpPost("Register")]
        public async Task<string> Register(UserRegisterDTO userRegisterDTO)
        {
            ResponseAjax result = new();
            if (ModelState.IsValid)
            {
                result = await _authLL.Register(userRegisterDTO); 
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMsg = ErrorMessage.InvalidModelMsg(userRegisterDTO);
            }
            return JsonSerializer.Serialize(result);
        }

        [HttpPost("Login")]
        public async Task<string> Login(UserLoginDTO userLoginDTO)
        {
            ResponseAjax result = new();
            if (ModelState.IsValid)
            {
                try
                {
                    result.Data = await _authLL.Login(userLoginDTO);
                }
                catch (IncorrectLoginDataExeption ex)
                {
                    result.IsSuccess = false;
                    result.ErrorMsg = ex.Message;
                }
            }
            else
            {
                result.IsSuccess = false;
                result.ErrorMsg = ErrorMessage.InvalidModelMsg(userLoginDTO);
            }
            return JsonSerializer.Serialize(result);
        }
    }
}
