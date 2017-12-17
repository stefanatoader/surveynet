import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule} from "@angular/forms";
import {SuiModule} from 'ng2-semantic-ui';
import {AuthenticationService} from "./services/authentication/authentication.service";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    SuiModule
  ],
  providers: [
    AuthenticationService
  ],
  declarations: [],
  exports: [
    FormsModule,
    HttpClientModule,
    SuiModule
  ]
})
export class SharedModule { }
