import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TopBarService } from 'src/app/services/top-bar.service';
import { UserService } from 'src/app/services/user.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  public isUserAuthenticated: boolean = false;
  userDetails;

  constructor(private _authService: AuthService, private router: Router, private service: UserService, private topBarService: TopBarService) { }

  ngOnInit(): void {
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

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    this.userDetails=null;
  }
}
