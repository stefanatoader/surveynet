import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {SuiModule} from 'ng2-semantic-ui';
import {AuthenticationService, tokenGetter} from "./services/authentication/authentication.service";
import {RouterModule} from "@angular/router";
import {CustomFormsModule} from "ng2-validation";
import {JwtModule, JwtHelperService} from "@auth0/angular-jwt";
import {AuthGuard} from "./guards/auth.guard";
import { NavbarComponent } from './components/navbar/navbar.component';
import { LogoComponent } from './components/logo/logo.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    SuiModule,
    RouterModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    }),
    CustomFormsModule
  ],
  providers: [
    AuthenticationService,
    AuthGuard,
    JwtHelperService
  ],
  declarations: [NavbarComponent, LogoComponent],
  exports: [
    FormsModule,
    HttpClientModule,
    SuiModule,
    RouterModule,
    CustomFormsModule,
    NavbarComponent,
    LogoComponent
  ]
})
export class SharedModule { }
