using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment
{
    class Admin : User
    {
        public Admin(string username, string password) : base(username, password) { }

        public override void Authenticate(string inputPassword)
        {
            Console.WriteLine($"Authenticating Admin: {Username}");
            if (VerifyPassword(inputPassword))
            {
                Console.WriteLine("Admin authenticated successfully!");
            }
            else
            {
                Console.WriteLine("Admin authentication failed!");
            }
        }
    }
}
