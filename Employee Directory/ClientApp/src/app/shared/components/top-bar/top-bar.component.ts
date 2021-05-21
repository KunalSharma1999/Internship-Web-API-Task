import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TopBarService } from 'src/app/services/top-bar.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  userDetails;

  constructor(private router: Router, private service: UserService, private topBarService: TopBarService) { }

  ngOnInit(): void {
    this.topBarService.notifyObservable$.subscribe(res => {
        this.service.getUserProfile().subscribe(
          res => {
            this.userDetails = res;
          },
          err => {
            console.log(err);
          },
        );
    })
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    this.userDetails=null;
  }
}
