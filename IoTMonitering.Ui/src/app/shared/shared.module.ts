import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { Page404Component } from './page404/page404.component';
import { CopyrightsComponent } from './copyrights/copyrights.component';
import { AppRoutingModule } from "../app-routing.module";
import { MatButtonModule } from "@angular/material/button"

@NgModule({
  declarations: [
    NavbarComponent,
    Page404Component,
    CopyrightsComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    MatButtonModule
],
  exports: [
    NavbarComponent,
    CopyrightsComponent
  ]

})
export class SharedModule { }
