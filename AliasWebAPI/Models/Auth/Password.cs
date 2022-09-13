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
            Hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            Salt = hasher.Key;
        }

        [Column("PASSWORD_HASH")]
        public byte[] Hash { get; set; }
        [Column("PASSWORD_SALT")]
        public byte[] Salt { get; set; }
    }

    public class PasswordString
    {
        public PasswordString() { }

        [Column("PASSWORD_HASH")]
        public string Hash { get; set; }
        [Column("PASSWORD_SALT")]
        public string Salt { get; set; }
    }
}
