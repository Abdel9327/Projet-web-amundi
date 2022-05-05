import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import{ AgGridModule }from'ag-grid-angular';
import { MenuComponent } from './menu/menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 

import {MatIconModule} from '@angular/material/icon'
import {MatDialogModule} from '@angular/material/dialog';
import { AddRequestComponent } from './add-request/add-request.component';
import { ModifyRequestComponent } from './modify-request/modify-request.component';
import { IdentificationComponent } from './identification/identification.component';
import { DataCheckerComponent } from './data-checker/data-checker.component';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    AddRequestComponent,
    ModifyRequestComponent,
    IdentificationComponent,
    DataCheckerComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AgGridModule.withComponents([]),
    HttpClientModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatDialogModule,
    FormsModule
  
    ],
    
  providers: [],
  bootstrap: [AppComponent],
  entryComponents:[MenuComponent,AddRequestComponent,ModifyRequestComponent] 
})
export class AppModule { }
