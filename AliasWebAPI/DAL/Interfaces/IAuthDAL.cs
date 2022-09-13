using AliasWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliasWebAPI.DAL
{
    public interface IAuthDAL
    {
        void AddUserProfileToDB(UserProfile userProfile);
        Task<Password> GetPasswordByUsername(string username);
    }
}
