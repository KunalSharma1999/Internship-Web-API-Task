import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Department } from '../models/Department';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  departments: Department[] = [];

  constructor(private http: HttpClient) { }

  url = `${environment.baseApi}/Departments`;

  refreshDepartments(){
    return this.http.get(this.url).toPromise().then(res => this.departments = res as Department[]);
  }

  getDepartmentById(id: number){
    return this.http.get<Department>(this.url + '/' + id);
  }

  addDepartment(department: Department): Observable<Department> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Department>(this.url, department, httpOptions);
  }

  updateDepartment(department: Department): Observable<Department> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Department>(this.url, department, httpOptions);
  }  
}
