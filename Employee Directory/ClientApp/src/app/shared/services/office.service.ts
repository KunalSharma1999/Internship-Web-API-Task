import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Office } from '../../models/Office';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  constructor(private http: HttpClient) { }

  url = 'https://localhost:44377/api/Employees';

  office: Office;

  getOffices(): Observable<Office[]> {
    return this.http.get<Office[]>(this.url + '/allofficedetails');
  }

  getOfficeById(id: number) {
    return this.http.get<Office>(this.url + '/getofficedetailsbyid/' + id).toPromise().then(res => this.office = res as Office);
  }

  addOffice(office: Office): Observable<Office> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Office>(this.url + '/insertofficedetails/',
      office, httpOptions);
  }

  updateOffice(office: Office): Observable<Office> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Office>(this.url + '/updateofficedetails/' + office.id,
      office, httpOptions);
  }  
}
