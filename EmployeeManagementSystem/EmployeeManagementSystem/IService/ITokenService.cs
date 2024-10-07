using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.IService
{
    public interface ITokenService
    {
        string GenerateJwtToken(string email, string userName);
    }
}
