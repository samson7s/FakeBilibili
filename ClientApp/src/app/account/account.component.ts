import { Component, OnInit } from '@angular/core';
import { Account } from '../account';
import { AuthenticationService } from '../authentication.service';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent implements OnInit {
  account:Account;
  returnUrl:'';
  error:string;
  submited:false;

  constructor(
    private fb:FormBuilder,
    private router:Router,
    private authenticationService:AuthenticationService
    ) { }

  loginForm=this.fb.group({
    account:[''],
    password:[''],    
  })
  ngOnInit() {
  }
   
  get formData(){
    return this.loginForm.controls;
  }

  onLogin(){    
    this.account.account=this.formData.account.value;
    this.account.password=this.formData.password.value;
    this.authenticationService.login(this.account)
        .pipe(first())
        .subscribe(
          data=>{
            this.router.navigate([this.returnUrl]);
          },
          error=>{
            this.error=error;            
          }
        );
  }
}
