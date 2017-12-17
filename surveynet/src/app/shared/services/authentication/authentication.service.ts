import { Injectable } from '@angular/core';

@Injectable()
export class AuthenticationService {

  private TOKEN_KEY: string = 'survey-token';
  private userInfo: any;

  constructor() { }

  login(userInfo) {
    this.userInfo = userInfo;
  }

  saveToken(token: string) {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  getToken(): string {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  isLogged(): boolean {
    return !!localStorage.getItem(this.TOKEN_KEY);
  }

  getUserInfo(): any {
    return this.userInfo;
  }
}
