import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7223/api/Employee';  // API endpoint
  private token: string | null = localStorage.getItem('jwtToken');

  constructor(private http: HttpClient) { }

  // getEmployees(): Observable<Employee[]> {
  //   return this.http.get<Employee[]>(`${this.apiUrl}/GetAllEmployees`);
  // }

  getEmployees(): Observable<Employee[]> {
    // Get the token from localStorage (or wherever you're storing it)
    const token = localStorage.getItem('jwtToken');

    // Add the Authorization header
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    return this.http.get<Employee[]>(`${this.apiUrl}/GetAllEmployees`, { headers });
  }

  getEmployeeById(id: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/${id}`);
  }

  addEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(`${this.apiUrl}/AddEmployee`, employee);
  }

  updateEmployee(id: number, employee: Employee): Observable<Employee> {
    return this.http.put<Employee>(`${this.apiUrl}/UpdateEmployee/${id}`, employee);
  }

  deleteEmployee(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/DeleteEmployee/${id}`);
  }
}
