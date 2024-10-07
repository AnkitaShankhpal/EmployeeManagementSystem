using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Service.Contract
{
    public interface ITokenService
    {
        string GenerateJwtToken(string email, string userName);
    }
}
