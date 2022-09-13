using AliasWebAPI.InternalServices;
using AliasWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AliasWebAPI.DAL
{
    public class AuthDAL : BaseDAL, IAuthDAL
    {
        private readonly SqlQueryService _sqlQueryService;

        public AuthDAL(IConfiguration configuration) : base(configuration)
        {
            _sqlQueryService = SqlQueryServiceFactory();
        }

        public async void AddUserProfileToDB(UserProfile userProfile)
        {
            var query = @"
                INSERT INTO UserProfile (USERNAME, EMAIL, PASSWORD_HASH, PASSWORD_SALT, ROLE) 
                VALUES (@username, @email, @passwordHash, @passwordSalt, @role) 
            ";
            var parameters = new
            {
                username = userProfile.UserName,
                email = userProfile.Email,
                passwordHash = userProfile.Password.Hash,
                passwordSalt = userProfile.Password.Salt,
                role = userProfile.Role,
            };
            await _sqlQueryService.ExecuteScalarAsync(query, parameters);
        }

        public async Task<Password> GetPasswordByUsername(string username)
        {
            var query = @"
                SELECT PASSWORD_HASH, PASSWORD_SALT FROM dbo.UserProfile 
                WHERE USERNAME = @username 
            ";
            var parameters = new
            {
                username
            };
            return (await _sqlQueryService.QueryAsync<Password>(query, parameters)).FirstOrDefault();
        }
    }
}
