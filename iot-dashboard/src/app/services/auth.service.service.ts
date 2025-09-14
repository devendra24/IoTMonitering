import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ServerInfo } from '../constants/ServerInfo';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  private baseUrl:string = "";

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
