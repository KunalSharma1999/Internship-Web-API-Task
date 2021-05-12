import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { EmployeeModule } from './employees/employees.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { EmployeeService } from './services/employee.service';
import { TopBarComponent } from './shared/components/top-bar/top-bar.component';
@NgModule({
  declarations: [
    AppComponent,
    TopBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    EmployeeModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [HttpClientModule, EmployeeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
