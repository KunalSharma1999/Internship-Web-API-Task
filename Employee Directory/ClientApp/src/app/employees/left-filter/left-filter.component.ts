import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { Filter } from 'src/app/models/Filter';
import { FilterOptions } from 'src/app/shared/enums/filter-options';
import { DepartmentService } from 'src/app/shared/services/department.service';
import { OfficeService } from 'src/app/shared/services/office.service';
import { JobTitleService } from 'src/app/shared/services/jobtitle.service';
import { Department } from '../../models/Department';
import { JobTitle } from '../../models/JobTitle';
import { Office } from '../../models/Office';

@Component({
  selector: 'app-left-filter',
  templateUrl: './left-filter.component.html',
  styleUrls: ['./left-filter.component.css']
})
export class LeftFilterComponent implements OnInit {

  @Output() filterSelected: EventEmitter<Filter> = new EventEmitter();

  departments: Department[] = [];
  offices: Office[] = [];
  jobTitles: JobTitle[] = [];

  get filterOption() {
      return FilterOptions;
  }

  constructor(private readonly departmentService: DepartmentService, private readonly officeService: OfficeService, private readonly jobTitleService: JobTitleService) {
  }

  ngOnInit() {
    this.departmentService.getDepartments().subscribe(departments => this.departments = departments);
    this.officeService.getOffices().subscribe(offices => this.offices = offices);
    this.jobTitleService.getJobTitles().subscribe(jobTitles => this.jobTitles = jobTitles);
  }

  setFilter(value: string, filterOption: FilterOptions) {
      const filter = new Filter({value: value, filterType: filterOption});
      this.filterSelected.emit(filter)
  }
  
  isDepartmentsExpanded = false;
  expandDepartments() {
    this.isDepartmentsExpanded = !this.isDepartmentsExpanded;
  }

  isOfficesExpanded = false;
  expandOffices() {
    this.isOfficesExpanded = !this.isOfficesExpanded;
  }

  isJobTitlesExpanded = false;
  expandJobTitles() {
    this.isJobTitlesExpanded = !this.isJobTitlesExpanded;
  }
}
