import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeftFilterComponent } from './left-filter/left-filter.component';
import { EmployeesComponent } from './employees/employees.component';
import { FormsModule , ReactiveFormsModule} from '@angular/forms';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { EmployeeFilterPipe } from '../pipes/employee-filter.pipe';



@NgModule({
  declarations: [
    LeftFilterComponent,
    EmployeesComponent,
    AddEmployeeComponent,
    EmployeeFilterPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    LeftFilterComponent,
    EmployeesComponent
  ]
})
export class EmployeeModule { }
