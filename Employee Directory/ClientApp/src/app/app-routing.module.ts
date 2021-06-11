import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees/employees.component';
import { ConfigurationsComponent } from './employees/configurations/configurations.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { SigninRedirectCallbackComponent } from './signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './signout-redirect-callback/signout-redirect-callback.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
 //{path: '', redirectTo:'user/login', pathMatch:'full'},
 //{ path:'user', component:UserComponent,
 // children: [
 //   {path: 'registration', component: RegistrationComponent },
 //   {path: 'login', component: LoginComponent },
 //   ]
 // },
  { path: 'employees', component: EmployeesComponent},
 // { path: 'configurations', component: ConfigurationsComponent, canActivate:[AuthGuard]},
  { path: 'home', component: HomeComponent },
  { path: 'signin-callback', component: SigninRedirectCallbackComponent },
  { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
  { path: '', redirectTo: '/employees', pathMatch: 'full' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
