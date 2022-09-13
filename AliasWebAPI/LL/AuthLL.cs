using AliasWebAPI.DAL;
using AliasWebAPI.Enums;
using AliasWebAPI.InternalServices;
using AliasWebAPI.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AliasWebAPI.LL
{
    public class AuthLL: IAuthLL, ILL
    {
        private readonly IAuthDAL _authDAL;
        private readonly IUserProfileLL _userProfileLL;
        public AuthLL(IAuthDAL authDAL, IUserProfileLL userProfileLL)
        {
            _authDAL = authDAL;
            _userProfileLL = userProfileLL;
        }

        public async Task<ResponseAjax> Register(UserRegisterDTO user)
        {
            ResponseAjax result = new();
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

        public async Task<string> Login(UserLoginDTO user)
        {
            if (await IsPasswordCorrect(user))
            {
                return "token";
            }
            throw new IncorrectLoginDataExeption(ErrorMessage.IncorrectLoginDataMsg(user));
        }

        private async Task<bool> IsPasswordCorrect(UserLoginDTO user)
        {
            Password realPassword = await _authDAL.GetPasswordByUsername(user.Username);
            var hasher = new HMACSHA512(realPassword.Salt);
            var passwordHash = hasher.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            return realPassword.Hash.SequenceEqual(passwordHash);
        }
    }
}
