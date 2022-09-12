using AliasWebAPI.Models;
using System.Threading.Tasks;

namespace AliasWebAPI.LL
{
    public interface IAuthLL: ILL
    {
        public Task<ResponseAjax> Register(UserRegisterDTO userRegisterDTO);
    }
}
