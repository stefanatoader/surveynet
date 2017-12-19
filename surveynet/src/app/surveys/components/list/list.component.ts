import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from "../../../shared/services/authentication/authentication.service";

@Component({
  selector: 'sn-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  public name: string;

  constructor(private auth: AuthenticationService) { }

  ngOnInit() {
    this.name = this.auth.getUserInfo().email;
  }

  logout(): void {
    this.auth.logout();
  }

}
