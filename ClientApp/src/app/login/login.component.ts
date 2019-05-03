  import { Component, OnInit, Input } from '@angular/core';
  import { AuthenticationService } from '../authentication.service';
  import { first } from 'rxjs/operators';
  import { Router, Route, ActivatedRoute } from '@angular/router';
  import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
  import { invalidAccountValidator } from '../../Shared/invalidAccount.directive';
import { Account } from '../Models/account';

  @Component({
    selector: 'app-account',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
  })
  export class LoginComponent implements OnInit {
    returnUrl: '';
    error: string;
    submitForm = false;
    submitted = false;
    account: Account = { account: "", password: "" }

    constructor(
      private fb: FormBuilder,
      private router: Router,
      private route: ActivatedRoute,
      private authenticationService: AuthenticationService
    ) { }

    loginForm: FormGroup = this.fb.group({
      account: ['', invalidAccountValidator()],
      password: ['', [Validators.required, Validators.minLength(5)]],
    })
    ngOnInit() {
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
      this.authenticationService.logout();
    }

    get formData() {
      return this.loginForm.controls;
    }

    get formAccount() {
      return this.loginForm.get('account');
    }

    get formPassword() {
      return this.loginForm.get('password');
    }

    onLogin() {
      if (this.loginForm.valid) {
        this.submitForm = true;
        this.submitted = true;
        this.account.account = this.formData.account.value;
        this.account.password = this.formData.password.value;
        this.error=null;
        this.authenticationService.login(this.account)
          .pipe(first())
          .subscribe(
            data => {
              this.router.navigate([this.returnUrl]);
            },
            error => {
              this.error = error;
              this.submitForm = false;
            }
          );
      }
    }
  }
