import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Department } from '../../models/Department';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }

  url = 'https://localhost:44377/api/Employees';

  department: Department;

  getDepartments(): Observable<Department[]>{
    return this.http.get<Department[]>(this.url+'/alldepartmentdetails');
  }

  getDepartmentById(id: number){
    return this.http.get<Department>(this.url + '/getdepartmentdetailsbyid/' + id).toPromise().then(res => this.department = res as Department);
  }

  addDepartment(department: Department): Observable<Department> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Department>(this.url + '/insertdepartmentdetails/',
      department, httpOptions);
  }

  updateDepartment(department: Department): Observable<Department> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Department>(this.url + '/updatedepartmentdetails/' + department.id,
      department, httpOptions);
  }  
}
