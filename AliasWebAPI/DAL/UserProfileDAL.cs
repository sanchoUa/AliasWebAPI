using AliasWebAPI.InternalServices;
using AliasWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AliasWebAPI.DAL
{
    public class UserProfileDAL: BaseDAL, IUserProfileDAL
    {
        private SqlQueryService _sqlQueryService;

        public UserProfileDAL(IConfiguration configuration) : base(configuration)
        {
            _sqlQueryService = SqlQueryServiceFactory();
        }
        public async Task<UserProfile> GetUserProfileByEmail(string email)
        {
            var query = @"
                SELECT * FROM dbo.UserProfile 
                Where EMAIL = @email 
            ";
            var parameters = new
            {
                email = email,
            };
            return await _sqlQueryService.ExecuteScalarAsync<UserProfile>(query, parameters);
        }

        public async Task<UserProfile> GetUserProfileByUsername(string username)
        {
            var query = @"
                SELECT * FROM dbo.UserProfile 
                Where USERNAME = @username 
            ";
            var parameters = new
            {
                username = username,
            };
            return await _sqlQueryService.ExecuteScalarAsync<UserProfile>(query, parameters);
        }
    }
}
