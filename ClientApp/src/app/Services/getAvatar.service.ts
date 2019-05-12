import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
    providedIn: 'root'
})
export class GetAvatarService {
    private avatarUrl = "api/account/GetAvatar/";

    constructor(private http: HttpClient) { }

    getAvatar() {
        const tokenInfo = JSON.parse(localStorage.getItem('TokenInfo'));
        if (tokenInfo && tokenInfo.token) {
            const helper=new JwtHelperService();
            const decodeToken=helper.decodeToken(tokenInfo.token);
            this.avatarUrl=this.avatarUrl+decodeToken.sub;            
        }
        return this.avatarUrl;
    }
}