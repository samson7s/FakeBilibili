import { Component, OnInit } from '@angular/core';
import { Account } from '../account';
import { AuthenticationService } from '../authentication.service';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {
  account:Account;

  constructor(private authenticationService:AuthenticationService,private router:Router) { }

  ngOnInit() {
  }
   
  login(){
    this.authenticationService.login(this.account)
    .pipe(first())
    .subscribe(data=>{});
  }
}
