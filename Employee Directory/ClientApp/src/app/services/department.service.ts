import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Department } from '../models/Department';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }

  url = `${environment.baseApi}/Departments`;

  department: Department;

  getDepartments(): Observable<Department[]>{
    return this.http.get<Department[]>(this.url+'/departments');
  }

  getDepartmentById(id: number){
    return this.http.get<Department>(this.url + '/getdepartment/' + id).toPromise().then(res => this.department = res as Department);
  }

  addDepartment(department: Department): Observable<Department> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Department>(this.url + '/savedepartment/',
      department, httpOptions);
  }

  updateDepartment(department: Department): Observable<Department> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Department>(this.url + '/savedepartment/',
      department, httpOptions);
  }  
}
