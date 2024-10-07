﻿namespace EmployeeManagementSystem.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public string? Password { get; set; }
    }

}
