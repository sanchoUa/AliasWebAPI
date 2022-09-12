using AliasWebAPI.InternalServices;
using AliasWebAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliasWebAPI.DAL
{
    public class AuthDAL : BaseDAL, IAuthDAL
    {
        private SqlQueryService _sqlQueryService;

        public AuthDAL(IConfiguration configuration) : base(configuration)
        {
            _sqlQueryService = SqlQueryServiceFactory();
        }

        public void AddUserProfileToDB(UserProfile userProfile)
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
            _sqlQueryService.ExecuteScalarAsync(query, parameters);
        }
    }
}
