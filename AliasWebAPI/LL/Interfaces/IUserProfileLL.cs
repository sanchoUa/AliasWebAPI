using System.Threading.Tasks;

namespace AliasWebAPI.LL
{
    public interface IUserProfileLL: ILL
    {
        Task<bool> DoesEmailExist(string email);
        Task<bool> DoesUsernameExist(string username);
    }
}
