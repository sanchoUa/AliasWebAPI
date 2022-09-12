using System.Security.Cryptography;
using System.Text;

namespace AliasWebAPI.Models
{
    public class Password
    {
        public Password(string password)
        {
            var hasher = new HMACSHA512();
            _hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            _salt = hasher.Key;
        }
        private byte[] _hash { get; set; }
        private byte[] _salt { get; set; }

        public byte[] Hash
        {
            get { return this._hash; }
        }

        public byte[] Salt
        {
            get { return this._salt; }
        }
    }
}
