import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Page404Component } from './shared/page404/page404.component';
import { authGuard } from './core/auth/auth.guard';
import { LoginComponent } from './features/auth/login/login.component';

const routes: Routes = [
  {path:'', redirectTo:'/dashboard',pathMatch:'full'},
  {path:'dashboard',
   loadChildren: () => import('./features/dashboard/dashboard.module').then(m=>m.DashboardModule),
    canActivate:[authGuard]},
  {path:'login' , component:LoginComponent},
  {path:'**',component:Page404Component}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
