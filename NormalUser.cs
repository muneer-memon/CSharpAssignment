using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment
{
    class NormalUser : User
    {
        public NormalUser(string username, string password) : base(username, password) { }

        public override void Authenticate(string inputPassword)
        {
            Console.WriteLine($"Authenticating Normal User: {Username}");
            if (VerifyPassword(inputPassword))
            {
                Console.WriteLine("Normal User authenticated successfully!");
            }
            else
            {
                Console.WriteLine("Normal User authentication failed!");
            }
        }
    }
}
