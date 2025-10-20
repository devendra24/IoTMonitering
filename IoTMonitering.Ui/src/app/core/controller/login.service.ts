import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private baseurl = environment.apiUrl
  private route = '/login'

  constructor(private httpClient:HttpClient) { }
  login():Observable<any>{
    return this.httpClient.get<any>(`${this.baseurl}${this.route}`);
  }
}
