import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees/employees.component';
import { ConfigurationsComponent } from './employees/configurations/configurations.component';

const routes: Routes = [
  { path: '', component: EmployeesComponent },
  { path: 'configurations-component', component: ConfigurationsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
