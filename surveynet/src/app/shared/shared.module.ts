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
  declarations: [],
  exports: [
    FormsModule,
    HttpClientModule,
    SuiModule,
    RouterModule,
    CustomFormsModule
  ]
})
export class SharedModule { }
