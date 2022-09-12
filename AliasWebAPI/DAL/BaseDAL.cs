using System.Collections.Generic;
using System.Threading.Tasks;
using AliasWebAPI.InternalServices;
using Microsoft.Extensions.Configuration;
using AliasWebAPI.Models;

namespace AliasWebAPI.DAL
{
    public class BaseDAL: IBaseDAL
    {
        protected string _connectionString;

        public BaseDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConnection");
        } 

        public SqlQueryService SqlQueryServiceFactory()
        {
            return new SqlQueryService(_connectionString);
        }
    }
}
