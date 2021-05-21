import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees/employees.component';
import { ConfigurationsComponent } from './employees/configurations/configurations.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
 {path: '', redirectTo:'user/login', pathMatch:'full'},
 { path:'user', component:UserComponent,
  children: [
    {path: 'registration', component: RegistrationComponent },
    {path: 'login', component: LoginComponent },
  ]},
  { path: 'employees', component: EmployeesComponent, canActivate:[AuthGuard]},
  { path: 'configurations', component: ConfigurationsComponent, canActivate:[AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
