using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CSharpAssignment
{

    // Base class for all users
    abstract class User
    {
        public string Username { get; set; }
        private string PasswordHash { get; set; } // Store hashed password

        public User(string username, string password)
        {
            Username = username;
            PasswordHash = HashPassword(password); // Hash the password during initialization
        }

        // Virtual method to be overridden by derived classes
        public virtual void Authenticate(string inputPassword)
        {
            Console.WriteLine("Authenticating user...");
        }

        // Helper method to hash passwords
        protected string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        // Helper method to verify passwords
        protected bool VerifyPassword(string inputPassword)
        {
            return HashPassword(inputPassword) == PasswordHash;
        }
    }
}
