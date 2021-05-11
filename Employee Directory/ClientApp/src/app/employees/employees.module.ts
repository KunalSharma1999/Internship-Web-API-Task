import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeftFilterComponent } from './left-filter/left-filter.component';
import { EmployeesComponent } from './employees/employees.component';
import { FormsModule , ReactiveFormsModule} from '@angular/forms';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { EmployeeFilterPipe } from '../pipes/employee-filter.pipe';
import { ConfigurationsComponent } from './configurations/configurations.component';
import { RouterModule } from '@angular/router'



@NgModule({
  declarations: [
    LeftFilterComponent,
    EmployeesComponent,
    AddEmployeeComponent,
    EmployeeFilterPipe,
    ConfigurationsComponent
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
