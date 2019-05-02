import { Component, OnInit, Input } from '@angular/core';
import { Account } from '../account';
import { AuthenticationService } from '../authentication.service';
import { first } from 'rxjs/operators';
import { Router, Route, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { RestrictedAccountValidator } from 'src/Shared/RestrictedAccount.directive';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent implements OnInit {
  returnUrl:'';
  error:string;
  submitForm=false;
  submitted=false;
  account:Account={account:"",password:""}

  constructor(
    private fb:FormBuilder,
    private router:Router,
    private route:ActivatedRoute,
    private authenticationService:AuthenticationService
    ) { }

  loginForm:FormGroup=this.fb.group({
    account:['',RestrictedAccountValidator],
    password:['',Validators.minLength(4)],    
  })
  ngOnInit() {
    this.returnUrl=this.route.snapshot.queryParams['returnUrl']||'/';
    this.authenticationService.logout();
  }
   
  get formData(){
    return this.loginForm.controls;
  }

  onLogin(){    
    this.submitForm=true;
    this.submitted=true;
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
            this.submitForm=false;
          }
        );
  }
}
