import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AUTH_ROUTE, BASE_URL } from '../constants/ServerInfo';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl:string = BASE_URL+AUTH_ROUTE;

  constructor(private http: HttpClient) { }

  login(credentials: any) {
    return this.http.post(`${this.baseUrl}/login`, credentials);
  }

  register(user: any) {
    return this.http.post(`${this.baseUrl}/register`, user);
  }

  setToken(token: string) {
    localStorage.setItem('jwt', token);
  }

  getToken() {
    return localStorage.getItem('jwt');
  }
}
