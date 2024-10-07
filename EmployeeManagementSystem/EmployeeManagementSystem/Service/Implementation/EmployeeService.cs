using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Repository.Contract;
using EmployeeManagementSystem.Service.Contract;
using EmployeeManagementSystem.Model;
using System.Security.Claims;

namespace EmployeeManagementSystem.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _employeeRepository.AddEmployee(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _employeeRepository.GetEmployeeByEmail(email);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task<Employee> EmployeeRegister(ApplicationUser user)
        {
            Employee employee = new Employee()
            {
                Email = user.Email,
                Password = user.Password,
            };
            return await _employeeRepository.AddEmployee(employee);
        }
    }
}
