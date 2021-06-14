import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobTitle } from '../models/JobTitle';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Constants } from '../shared/constants';

@Injectable({
  providedIn: 'root'
})
export class JobTitleService {

  jobTitles: JobTitle[] = [];

  constructor(private http: HttpClient) { }

  url = `${environment.urlAddress}/` + Constants.jobTitleRoute;

  refreshJobTitles() {
    return this.http.get(this.url).toPromise().then(res => this.jobTitles = res as JobTitle[])
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
