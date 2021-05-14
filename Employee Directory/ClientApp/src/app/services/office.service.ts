import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Office } from '../models/Office';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  constructor(private http: HttpClient) { }

  url = `${environment.baseApi}/Offices`;

  getOffices(): Observable<Office[]> {
    return this.http.get<Office[]>(this.url);
  }

  getOfficeById(id: number) {
    return this.http.get<Office>(this.url + '/' + id);
  }

  addOffice(office: Office): Observable<Office> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<Office>(this.url, office, httpOptions);
  }

  updateOffice(office: Office): Observable<Office> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<Office>(this.url, office, httpOptions);
  }  
}
