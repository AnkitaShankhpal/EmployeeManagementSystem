import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee';


@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.getEmployees().subscribe(data => {
      this.employees = data;
    });
  }

  deleteEmployee(employeeId: number | undefined): void {
    if (employeeId === undefined) {
      console.error("Employee ID is undefined, cannot delete.");
      return;
    }
  
    this.employeeService.deleteEmployee(employeeId).subscribe({
      next: () => {
        console.log(`Employee with ID: ${employeeId} has been deleted.`);
        // Optionally, refresh the employee list after deletion:
        this.employeeService.getEmployees().subscribe(data => {
          this.employees = data;
        });
      },
      error: (err) => {
        console.error(`Failed to delete employee with ID: ${employeeId}. Error: ${err}`);
      }
    });
  }
  
}
