using AliasWebAPI.Enums;
using System;

namespace AliasWebAPI.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Password Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Role Role { get; set; }
    }
}
