using AliasWebAPI.LL;
using AliasWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading.Tasks;

namespace AliasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private IUserProfileLL _userProfileLL;

        public UserProfileController(IUserProfileLL userProfileLL)
        {
            _userProfileLL = userProfileLL;
        }

        [HttpGet("DoesEmailExist")]
        public async Task<string> DoesEmailExist(string email)
        {
            ResponseAjax result = new ResponseAjax();
            result.Data = await _userProfileLL.DoesEmailExist(email);
            return JsonSerializer.Serialize(result);
        }

        [HttpGet("DoesUsernameExist")]
        public async Task<string> DoesUsernameExist(string username)
        {
            ResponseAjax result = new ResponseAjax();
            result.Data = await _userProfileLL.DoesUsernameExist(username);
            return JsonSerializer.Serialize(result);
        }
    }
}
