import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { Employee } from '../models/Employee';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url = `${environment.baseApi}/Employees`;

  employees: Employee[]; 
  constructor(private http: HttpClient) {
  }

  refreshEmployees(){  
    return this.http.get(this.url).toPromise().then(res => this.employees = res as Employee[]);
  }   

  getEmployeeById(id:number): Observable<Employee> {  
    return this.http.get<Employee>(this.url + '/' + id);  
  }

  addEmployee(employee: Employee): Observable<Employee> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Employee>(this.url, employee, httpOptions);
  }  

  updateEmployee(employee: Employee): Observable<Employee> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Employee>(this.url, employee, httpOptions);  
  }  
}
