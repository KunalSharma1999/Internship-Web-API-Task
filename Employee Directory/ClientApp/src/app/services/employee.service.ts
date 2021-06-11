import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { Employee } from '../models/Employee';
import { environment } from '../../environments/environment';
import { EmployeeCard } from '../models/EmployeeCard';
import { Constants } from '../shared/constants';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';
import { AuthService } from '../shared/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url = Constants.apiRoot+"/Employees";
  
  route = "api/Employees";

  employees: EmployeeCard[] = [];

  constructor(private http: HttpClient,  private envUrl: EnvironmentUrlService, private _authService: AuthService) {
  }

  public getEmployees = () => {
    return this.http.get(this.createCompleteRoute(this.route, this.envUrl.urlAddress));
  }
 
  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
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
