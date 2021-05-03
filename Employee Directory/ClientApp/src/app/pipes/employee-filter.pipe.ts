import { Pipe, PipeTransform } from '@angular/core';
import { Employee } from '../models/Employee';
import { Filter } from '../models/Filter';
import { FilterOptions } from '../shared/enums/filter-options';

@Pipe({
  name: 'employeeFilter'
})
export class EmployeeFilterPipe implements PipeTransform {
  transform(employees: Employee[], filter: Filter, alphabetFilter: string, searchKeyword: string, filterBy: string) {
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
            return employee.PreferredName.toLowerCase().startsWith(alphabetFilter.toLowerCase());
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
                return employee.Department.toLowerCase().includes(searchKeyword) ||
                    employee.JobTitle.toLowerCase().includes(searchKeyword) ||
                    employee.PreferredName.toLowerCase().includes(searchKeyword);
            });
        }
    }

    return employees;
}
}
