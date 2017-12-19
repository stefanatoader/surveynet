import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from "./login/components/login/login.component";
import {RegisterComponent} from "./login/components/register/register.component";
import {AuthGuard} from "./shared/guards/auth.guard";
import {ListComponent} from "./surveys/components/list/list.component";

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'forms', component: ListComponent, canActivate: [AuthGuard]},
  {path: '**', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
