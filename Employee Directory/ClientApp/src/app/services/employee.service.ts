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

  employees;

  constructor(private http: HttpClient) {
  }

  refreshEmployees(){  
    return this.http.get(this.url).toPromise().then(res => this.employees = res);
  }   

  getEmployeeById(id: number):any {
    return this.http.get(this.url + '/' + id).toPromise();  
  }

  addEmployee(employee: Employee): Observable<Employee> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Employee>(this.url, employee, httpOptions);
  }  

  updateEmployee(employee: Employee): Observable<Employee> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Employee>(this.url, employee, httpOptions);  
  }

  deleteEmployee(id: number): Observable<Employee> {
    return this.http.delete<Employee>(this.url + '/' + id);
  }
}
