import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Account } from './account';
import { map} from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {  
  private loginUrl:string="api/account/login";

  constructor(private http:HttpClient) { }

  login(account:Account){
    return this.http.post<any>(this.loginUrl,JSON.stringify(account),httpOptions).pipe(
        map(user=>{
          if(user&&user.token){
            localStorage.setItem('TokenInfo',JSON.stringify(user));
          }
          return user;
        })
    );
  }

  logout(){
    localStorage.removeItem("TokenInfo");
  }
}
