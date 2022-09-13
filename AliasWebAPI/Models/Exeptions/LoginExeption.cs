using System;

namespace AliasWebAPI.Models
{
    public class IncorrectLoginDataExeption: Exception
    {
        public IncorrectLoginDataExeption()
        {
        }

        public IncorrectLoginDataExeption(string message)
            : base(message)
        {
        }

        public IncorrectLoginDataExeption(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
