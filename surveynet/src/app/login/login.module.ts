import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import {SharedModule} from "../shared/shared.module";
import {LoginService} from "./services/login/login.service";

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  providers: [
    LoginService
  ],
  declarations: [LoginComponent, RegisterComponent]
})
export class LoginModule { }
