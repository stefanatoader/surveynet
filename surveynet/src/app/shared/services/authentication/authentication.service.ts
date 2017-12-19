import { Injectable } from '@angular/core';
import {JwtHelperService} from "@auth0/angular-jwt";
import {Router} from "@angular/router";

@Injectable()
export class AuthenticationService {

  private TOKEN_KEY: string = 'survey-token';
  private userInfo: any;

  constructor(private jwtHelper: JwtHelperService, private router: Router) { }

  login(userInfo) {
    this.userInfo = userInfo;
  }

  saveToken(token: string) {
    localStorage.setItem(this.TOKEN_KEY, token);
    this.userInfo = this.jwtHelper.decodeToken(token);
    console.log(this.userInfo);
  }

  getToken(): string {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  isLogged(): boolean {
    const token = this.getToken();
    return token != undefined && token != '';
  }

  getUserInfo(): any {
    if (!this.userInfo) {
      this.userInfo = this.jwtHelper.decodeToken(this.getToken());
    }
    return this.userInfo;
  }

  logout(): void {
    localStorage.setItem(this.TOKEN_KEY, '');
    this.router.navigate(['/login']);
  }
}

export function tokenGetter() {
  return localStorage.getItem(this.TOKEN_KEY);
};
