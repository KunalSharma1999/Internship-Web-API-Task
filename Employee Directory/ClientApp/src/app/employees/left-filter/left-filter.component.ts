import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';
import { Filter } from 'src/app/models/Filter';
import { FilterOptions } from 'src/app/shared/enums/filter-options';
import { LookupService } from 'src/app/shared/services/lookup.service';

@Component({
  selector: 'app-left-filter',
  templateUrl: './left-filter.component.html',
  styleUrls: ['./left-filter.component.css']
})
export class LeftFilterComponent implements OnInit {

  @Output() filterSelected: EventEmitter<Filter> = new EventEmitter();

  departments: string[] = [];
  offices: string[] = [];
  jobTitles: string[] = [];

  get filterOption() {
      return FilterOptions;
  }

  constructor(private readonly lookupService: LookupService) {
  }

  ngOnInit() {
      this.departments = this.lookupService.getDepartments();
      this.offices = this.lookupService.getOffices();
      this.jobTitles = this.lookupService.getJobTitles();
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
