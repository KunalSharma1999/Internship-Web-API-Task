import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LookupService {
  getDepartments() {
    return ['IT', 'Human Resources', 'MD', 'Sales'];
}

getOffices() {
    return ['Seattle', 'India'];
}

getJobTitles() {
    return ['SharePoint Practise Head', '.Net Development Lead', 'Recruiting Expert', 'BI Developer', 'Business Analyst'];
}
}
