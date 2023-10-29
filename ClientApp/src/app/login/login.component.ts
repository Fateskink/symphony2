import { Component, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
@Injectable()
export class LoginComponent {
  private apiUrl = 'http://localhost:5001';
  email: string = '';
  password: string = '';

  constructor(private http: HttpClient) {}

  onLogin() {
    this.login(this.email, this.password);
  }

  login(email: string, password: string) {
    const data = {
      Email: email,
      Password: password,
    };

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    return this.http.post(`${this.apiUrl}/api/auth/signin`, data, { headers });
  }
}
