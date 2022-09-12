using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliasWebAPI.InternalServices
{
    public sealed class ErrorMessage
    {
        public static string InvalidModelMsg(object invalidObject)
        {
            return $"Invalid Model -> {invalidObject}";
        }

        public static string UsingExistingEmailMsg(string invalidEmail)
        {
            return $"Using existing E-mail -> {invalidEmail}";
        }

        public static string UsingExistingUsernameMsg(string invalidUsername)
        {
            return $"Using existing Username -> {invalidUsername}";
        }
    }
}
