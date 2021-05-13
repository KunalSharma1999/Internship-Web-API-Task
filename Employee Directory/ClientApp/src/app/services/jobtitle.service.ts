import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobTitle } from '../models/JobTitle';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobTitleService {

  constructor(private http: HttpClient) { }

  url = `${environment.baseApi}/JobTitles`;

  jobTitle: JobTitle;

  getJobTitles(): Observable<JobTitle[]> {
    return this.http.get<JobTitle[]>(this.url);
  }

  getJobTitleById(id: number) {
    return this.http.get(this.url + '/' + id).pipe(map((data: JobTitle) => { return data}));
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
