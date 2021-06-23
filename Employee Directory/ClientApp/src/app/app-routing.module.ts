import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees/employees.component';
import { SigninRedirectCallbackComponent } from './signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './signout-redirect-callback/signout-redirect-callback.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ConfigurationsComponent } from './employees/configurations/configurations.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { AuthGuardService } from './shared/guards/auth-guard.service';

const routes: Routes = [
 {path: '', redirectTo:'user/registration', pathMatch:'full'},
 { path:'user', component:UserComponent,
  children: [
    {path: 'registration', component: RegistrationComponent }
  ]},
  { path: 'privacy', component: PrivacyComponent,  canActivate: [AuthGuardService], data: { roles: ['Admin'] } },
  { path: 'unauthorized', component: UnauthorizedComponent },
  { path: 'employees', component: EmployeesComponent,canActivate: [AuthGuardService]},
  { path: 'configurations', component: ConfigurationsComponent,canActivate: [AuthGuardService], data: { roles: ['Admin'] } },
  { path: 'signin-callback', component: SigninRedirectCallbackComponent },
  { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
