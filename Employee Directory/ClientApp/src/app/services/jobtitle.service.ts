import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobTitle } from '../models/JobTitle';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobTitleService {

  constructor(private http: HttpClient) { }

  url = `${environment.baseApi}/JobTitles`;

  getJobTitles(): Observable<JobTitle[]> {
    return this.http.get<JobTitle[]>(this.url);
  }

  getJobTitleById(id: number) {
    return this.http.get<JobTitle>(this.url + '/' + id);
  }

  addJobTitle(jobTitle: JobTitle): Observable<JobTitle> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<JobTitle>(this.url, jobTitle, httpOptions);
  }

  updateJobTitle(jobTitle: JobTitle): Observable<JobTitle> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<JobTitle>(this.url, jobTitle, httpOptions);
  }  
}
