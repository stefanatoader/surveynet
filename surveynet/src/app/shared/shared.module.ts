import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {SuiModule} from 'ng2-semantic-ui';
import {AuthenticationService} from "./services/authentication/authentication.service";
import {RouterModule} from "@angular/router";
import {CustomFormsModule} from "ng2-validation";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    SuiModule,
    RouterModule,
    CustomFormsModule
  ],
  providers: [
    AuthenticationService
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
