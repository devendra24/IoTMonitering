import { Injectable } from '@angular/core';
import { LoginService } from '../controller/login.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userID:string = "userid"
  constructor(private loginService:LoginService,private router:Router) { }

  isUserLoggedIn(): boolean {
    return !!localStorage.getItem(this.userID);
  }

  login():boolean {
    this.loginService.login().subscribe({
      next:(token)=>{
      localStorage.setItem(this.userID, token.id);
      this.router.navigate(['dashboard']);
      },
      error:(err)=>{
        console.log(err)
      }
    })

    return true;
  }

  logout() {
    localStorage.removeItem(this.userID);
    this.router.navigate(['']);
  }
}
