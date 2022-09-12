using AliasWebAPI.DAL;
using AliasWebAPI.Enums;
using AliasWebAPI.InternalServices;
using AliasWebAPI.Models;
using System;
using System.Threading.Tasks;

namespace AliasWebAPI.LL
{
    public class AuthLL: IAuthLL, ILL
    {
        private IAuthDAL _authDAL;
        private IUserProfileLL _userProfileLL;
        public AuthLL(IAuthDAL authDAL, IUserProfileLL userProfileLL)
        {
            _authDAL = authDAL;
            _userProfileLL = userProfileLL;
        }

        public async Task<ResponseAjax> Register(UserRegisterDTO user)
        {
            ResponseAjax result = new ResponseAjax();
            if (await _userProfileLL.DoesEmailExist(user.Email))
            {
                result.IsSuccess = false;
                result.ErrorMsg = ErrorMessage.UsingExistingEmailMsg(user.Email);
            }
            else if (await _userProfileLL.DoesUsernameExist(user.Username))
            {
                result.IsSuccess = false;
                result.ErrorMsg = ErrorMessage.UsingExistingUsernameMsg(user.Username);
            }
            else
            {
                var userProfile = new UserProfile
                {
                    UserName = user.Username,
                    Email = user.Email,
                    Password = new Password(user.Password),
                    Role = Role.Player,
                };
                _authDAL.AddUserProfileToDB(userProfile);
            }
            return result;
        }
    }
}
