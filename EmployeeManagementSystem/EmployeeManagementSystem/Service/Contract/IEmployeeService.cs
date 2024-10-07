using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Service.Contract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> EmployeeRegister(ApplicationUser user);
        Task DeleteEmployee(int id);
    }
}
