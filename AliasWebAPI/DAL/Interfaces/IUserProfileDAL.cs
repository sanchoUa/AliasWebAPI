using AliasWebAPI.Models;
using System.Threading.Tasks;

namespace AliasWebAPI.DAL
{
    public interface IUserProfileDAL
    {
        public Task<UserProfile> GetUserProfileByEmail(string email);
        public Task<UserProfile> GetUserProfileByUsername(string username);
    }
}
