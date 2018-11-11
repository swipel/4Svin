import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { FarmManagementComponent } from './farm-management/farm-management.component';
import { RoutingModule } from './routing/routing.module';
import { StatisticsComponent } from './statistics/statistics.component';
import { BoxDetailsComponent } from './box-details/box-details.component';
import {FormsModule} from '@angular/forms';

import {Globals} from './Globals';


@NgModule({
  declarations: [
    AppComponent,
    FarmManagementComponent,
    StatisticsComponent,
    BoxDetailsComponent
  ],
  imports: [
    BrowserModule, RoutingModule, HttpClientModule, FormsModule
  ],
  providers: [Globals],
  bootstrap: [AppComponent]
})
export class AppModule { }
