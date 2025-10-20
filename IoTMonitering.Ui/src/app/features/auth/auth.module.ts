import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { AuthService } from '../../core/auth/auth.service';
import { RegisterComponent } from './register/register.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  providers:[AuthService],
  imports: [
    CommonModule,
  ]
})
export class LoginModule { }
