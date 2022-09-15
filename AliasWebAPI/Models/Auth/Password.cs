using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace AliasWebAPI.Models
{
    public class Password
    {
        public Password() { }
        public Password(string password)
        {
            var hasher = new HMACSHA512();
            Password_hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            Password_salt = hasher.Key;
        }

        public byte[] Password_hash { get; set; }
        public byte[] Password_salt { get; set; }
    }
}
