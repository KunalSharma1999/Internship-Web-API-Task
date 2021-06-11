import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TopBarService } from 'src/app/services/top-bar.service';
import { UserService } from 'src/app/services/user.service';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public isUserAuthenticated: boolean = false;

  formModel = {
    UserName: '',
    Password: ''
  }
  constructor(private _authService: AuthService, private service: UserService, private router: Router, private toastr: ToastrService, private topBarService: TopBarService) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/employees');

    this._authService.loginChanged
      .subscribe(res => {
        this.isUserAuthenticated = res;
      })
  }

  public login = () => {
    this._authService.login();
  }

  public logout = () => {
    this._authService.logout();
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/employees');
        this.topBarService.notifyOther({refresh: true})
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }
}
