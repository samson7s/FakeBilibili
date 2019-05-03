import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NavHeadComponent } from './nav-head/nav-head.component';
import { tokenInterceptor } from './Interceptor/tokenInterceptor';
import { unauthorizedInterceptor } from './Interceptor/unauthorizedInterceptor';
import { LoginComponent } from './login/login.component';
import { AuthenticationService } from './Services/authentication.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavHeadComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:tokenInterceptor,multi:true},
    {provide:HTTP_INTERCEPTORS,useClass:unauthorizedInterceptor,multi:true},
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
