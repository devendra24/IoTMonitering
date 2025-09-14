import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { DeviceListComponent } from './components/device-list/device-list.component';
import { authGuard } from './guards/auth.guard';
import { devicesResolver } from './devices.resolver';

export const routes: Routes = [
    {path:'',redirectTo:'devices',pathMatch:'full'},
    {path:'login',component:LoginComponent},
    {path:'register',component:RegisterComponent},
    {path:'devices',component:DeviceListComponent,canActivate:[authGuard],resolve:{devicesData:devicesResolver}}
];
