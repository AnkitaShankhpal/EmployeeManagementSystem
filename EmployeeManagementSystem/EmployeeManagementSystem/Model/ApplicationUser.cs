using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
