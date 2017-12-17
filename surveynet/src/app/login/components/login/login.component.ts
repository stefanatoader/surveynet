import {Component, OnInit, ViewChild} from '@angular/core';
import {LoginService} from "../../services/login/login.service";

@Component({
  selector: 'sn-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @ViewChild('loginForm') loginForm;

  public loading: boolean = false;
  public error: boolean = false;

  constructor(private loginService: LoginService) { }

  ngOnInit() {
  }

  submit(loginModel): void {
    this.loading = true;
    this.loginService.login(loginModel).subscribe(res => {
      this.loading = false;
      this.error = false;
    }, () => {
      this.loading = false;
      this.error = true;
    })
  }

}
