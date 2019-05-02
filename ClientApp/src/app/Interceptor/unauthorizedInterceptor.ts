import { Injectable } from '@angular/core';
import { HttpInterceptor } from '@angular/common/http';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
@Injectable()
export class unauthorizedInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService, private router: Router) { }

    intercept(req: import("@angular/common/http").HttpRequest<any>, next: import("@angular/common/http").HttpHandler): import("rxjs").Observable<import("@angular/common/http").HttpEvent<any>> {
        return next.handle(req).pipe(catchError(err => {
            if (err.status == 401) {
                this.authenticationService.logout();
            }
            const error = err.error.message || err.statusText;
            return Observable.throw(error);
        }))
    }
}