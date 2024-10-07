using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmployeeManagementSystem.Model;
using Microsoft.AspNetCore.Identity;
using EmployeeManagementSystem.Service;
using EmployeeManagementSystem.DTOs;
using Microsoft.AspNetCore.Authorization;
using EmployeeManagementSystem.Service.Contract;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmployeeService _employeeService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService,IEmployeeService employeeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _employeeService = employeeService;
        }

        // POST: api/account/register
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseModel>> Register([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEmployee = await _employeeService.GetEmployeeByEmail(model.Email);
          
            if (existingEmployee != null)
            {
                // Return a specific message if the user already exists
                ModelState.AddModelError("Email", "Already have an account.");
                return BadRequest(ModelState);
            }

            var token = _tokenService.GenerateJwtToken(model.Email, model.Password);

            var employee = new Employee
            {
                Email = model.Email,
                Password = model.Password,
            };

            try
            {
                var result = await _employeeService.AddEmployee(employee);
                var response = new RegisterResponseModel
                {
                    Email = result.Email,
                    Token = token
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(new { Message = "User registered successfully." });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO model)
        {
            if (model.Email == "Admin23@gmail.com" && model.Password == "Admin@123")
            {
                var token = _tokenService.GenerateJwtToken(model.Email, "Admin");
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

    }
}
