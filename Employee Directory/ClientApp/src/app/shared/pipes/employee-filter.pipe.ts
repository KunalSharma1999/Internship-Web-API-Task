import { Pipe, PipeTransform } from '@angular/core';
import { Employee } from '../../models/Employee';
import { Filter } from '../../models/Filter';
import { FilterOptions } from '../enums/filter-options';

@Pipe({
  name: 'employeeFilter'
})
export class EmployeeFilterPipe implements PipeTransform {
  transform(employees, filter: Filter, alphabetFilter: string, searchKeyword: string, filterBy: string) {
    if (filter && !alphabetFilter && !searchKeyword) {
        switch (filter.filterType) {
            case FilterOptions.Department:
            case FilterOptions.JobTitle:
            case FilterOptions.Office: {
                employees = employees.filter(employee => {
                    return employee[filter.filterType] === filter.value;
                });
                break;
            }
        }
    }

    if (alphabetFilter) {
        employees = employees.filter(employee => {
            return employee.preferredName.toLowerCase().startsWith(alphabetFilter.toLowerCase());
        });
    }

    if (searchKeyword) {
        searchKeyword = searchKeyword.toLowerCase();

        if (filterBy) {
            employees = employees.filter(employee => {
                return employee[filterBy].toLowerCase().includes(searchKeyword);
            });
        }
        else {
            employees = employees.filter(employee => {
                return employee.department.toLowerCase().includes(searchKeyword) ||
                    employee.jobTitle.toLowerCase().includes(searchKeyword) ||
                    employee.preferredName.toLowerCase().includes(searchKeyword);
            });
        }
    }

    return employees;
}
}
