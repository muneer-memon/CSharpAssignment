# Assignment I

 *Do you think design of below interface is correct ?*

```interface StudentRegistrationAdmission
{
ResgisterStudent();
InitiateAdmissionProcedure();
CalcualteFees();
PayFees();
SendRegistrationDetailsSms();
SendEmailToStudent();
SendPaymentReceiptOnEmail();
}
```

*If Yes (Incorrect Answer), Why?*
*If No, Is there any way to Improve design of this interface?*

# No, it violates single responsibility principle, it also has tight coupling. It has incorrect words for the methods and has poor naming conventions. There is a room for separation of concerns also.

```interface IStudentRegistration
{
    void RegisterStudent();
}

interface IAdmissionProcedure
{
    void InitiateAdmissionProcedure();
}

interface IFeeCalculator
{
    decimal CalculateFees();
}

interface IFeePayment
{
    void PayFees();
}

interface ICommunicationService
{
    void SendSms(string message, string recipient);
    void SendEmail(string subject, string body, string recipient);
}
```


# Assignment II
Tech: C#, .NET

*We have a task to implement user authentication mechanism to authenticate user based on user role (Admin, SuperAdmin, Normal User). Can you please help me to implement this mechanism using Runtime Polymorphism in C#

```using System;
using System.Security.Cryptography;
using System.Text;

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

// Derived class for Admin
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

// Derived class for SuperAdmin
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

// Derived class for NormalUser
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

class Program
{
    static void Main(string[] args)
    {
        // Create users of different roles
        User normalUser = new NormalUser("user", "user000");
        User superAdmin = new SuperAdmin("superadmin", "superadmin000");
        User admin = new Admin("admin", "admin000");

        // Authenticate users using runtime polymorphism
        AuthenticateUser(admin, "admin000");
        AuthenticateUser(superAdmin, "superadmin000");
        AuthenticateUser(normalUser, "user000");

        // Test with incorrect credentials
        AuthenticateUser(normalUser, "abc1123");
    }

    // Method to demonstrate runtime polymorphism
    static void AuthenticateUser(User user, string inputPassword)
    {
        user.Authenticate(inputPassword);
    }
}
```
