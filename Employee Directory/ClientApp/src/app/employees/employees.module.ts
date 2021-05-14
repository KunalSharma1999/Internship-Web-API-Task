import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeftFilterComponent } from './left-filter/left-filter.component';
import { EmployeesComponent } from './employees/employees.component';
import { FormsModule , ReactiveFormsModule} from '@angular/forms';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { ConfigurationsComponent } from './configurations/configurations.component';
import { RouterModule } from '@angular/router'
import { EmployeeFilterPipe } from '../shared/pipes/employee-filter.pipe';
import { DepartmentsComponent } from './configurations/departments/departments.component';
import { OfficesComponent } from './configurations/offices/offices.component';
import { JobTitlesComponent } from './configurations/job-titles/job-titles.component';



@NgModule({
  declarations: [
    LeftFilterComponent,
    EmployeesComponent,
    AddEmployeeComponent,
    EmployeeFilterPipe,
    ConfigurationsComponent,
    DepartmentsComponent,
    OfficesComponent,
    JobTitlesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    LeftFilterComponent,
    EmployeesComponent,
    ConfigurationsComponent
  ]
})
export class EmployeeModule { }
