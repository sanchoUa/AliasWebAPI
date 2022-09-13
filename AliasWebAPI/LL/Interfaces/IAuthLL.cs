using AliasWebAPI.Models;
using System.Threading.Tasks;

namespace AliasWebAPI.LL
{
    public interface IAuthLL: ILL
    {
        Task<ResponseAjax> Register(UserRegisterDTO userRegisterDTO);
        Task<string> Login(UserLoginDTO user);
    }
}
