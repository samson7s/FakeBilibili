import { Injectable } from '@angular/core';
import { HttpInterceptor } from '@angular/common/http';
@Injectable()
export class tokenInterceptor implements HttpInterceptor {
    intercept(req: import("@angular/common/http").HttpRequest<any>, next: import("@angular/common/http").HttpHandler)
        : import("rxjs").Observable<import("@angular/common/http").HttpEvent<any>> {
        let tokenInfo = JSON.parse(localStorage.getItem('TokenInfo'));
        if (tokenInfo && tokenInfo.token) {
            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${tokenInfo.token}`,
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8'
                }
            });
        }
        return next.handle(req);
    }

}