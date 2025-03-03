using CSharpAssignment;
User normalUser = new NormalUser("user", "user000");
User superAdmin = new SuperAdmin("superadmin", "superadmin000");
User admin = new Admin("admin", "admin000");

// Authenticate users using runtime polymorphism
AuthenticateUser(admin, "admin000");
AuthenticateUser(superAdmin, "superadmin000");
AuthenticateUser(normalUser, "user000");

// Test with incorrect credentials
AuthenticateUser(normalUser, "abc1123");


// Method to demonstrate runtime polymorphism
static void AuthenticateUser(User user, string inputPassword)
{
    user.Authenticate(inputPassword);
}