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
        private IAuthLL _authLL;

        public AuthController(IAuthLL authLL)
        {
            _authLL = authLL;
        }

        [HttpPost]
        public async Task<string> Register(UserRegisterDTO userRegisterDTO)
        {
            ResponseAjax result = new ResponseAjax();
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
    }
}
