using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment
{
    class SuperAdmin : User
    {
        public SuperAdmin(string username, string password) : base(username, password) { }

        public override void Authenticate(string inputPassword)
        {
            Console.WriteLine($"Authenticating SuperAdmin: {Username}");
            if (VerifyPassword(inputPassword))
            {
                Console.WriteLine("SuperAdmin authenticated successfully!");
            }
            else
            {
                Console.WriteLine("SuperAdmin authentication failed!");
            }
        }
    }
}
