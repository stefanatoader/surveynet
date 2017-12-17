import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable()
export class LoginService {

  private url: string = '/api/accounts';
  private createTokenURL: string = '/api/token';

  constructor(private http: HttpClient) { }

  createAccount(account) {
    return this.http.post(this.url, account);
  }

  login(loginModel) {
    return this.http.post(this.createTokenURL, loginModel);
  }

}
