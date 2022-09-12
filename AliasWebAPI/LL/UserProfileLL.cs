using AliasWebAPI.DAL;
using AliasWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliasWebAPI.LL
{
    public class UserProfileLL : IUserProfileLL
    {
        private IUserProfileDAL _userProfileDAL;
        public UserProfileLL(IUserProfileDAL userProfileDAL)
        {
            _userProfileDAL = userProfileDAL;
        }

        public async Task<bool> DoesEmailExist(string email)
        {
            UserProfile machedUser = await _userProfileDAL.GetUserProfileByEmail(email);
            return machedUser != null;
        }

        public async Task<bool> DoesUsernameExist(string username)
        {
            UserProfile machedUser = await _userProfileDAL.GetUserProfileByUsername(username);
            return machedUser != null;
        }
    }
}
