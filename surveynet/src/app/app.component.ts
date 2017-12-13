import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'sn-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  accounts: any[];

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.http.get('/api/accounts').subscribe((res: any[]) => {
      this.accounts = res;
    });
  }
}
