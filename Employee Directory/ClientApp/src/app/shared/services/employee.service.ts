import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { Employee } from '../../models/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url = 'https://localhost:44377/api/Employees';

  employees: Employee[]; 
  constructor(private http: HttpClient) {
  }

  addEmployee(employee:Employee): Observable<Employee> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post<Employee>(this.url + '/InsertEmployeeDetails/',  
    employee, httpOptions);  
  }  

  refreshEmployees(){  
    return this.http.get(this.url + '/AllEmployeeDetails').toPromise().then(res => this.employees = res as Employee[]); 
  }   

  getEmployeeById(id:number): Observable<Employee> {  
    return this.http.get<Employee>(this.url + '/GetEmployeeDetailsById/' + id);  
  }  

  updateEmployee(employee: Employee): Observable<Employee> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Employee>(this.url + '/UpdateEmployeeDetails/' + employee.id,  
    employee, httpOptions);  
  }  
}
