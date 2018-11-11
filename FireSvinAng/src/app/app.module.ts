import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { FarmManagementComponent } from './farm-management/farm-management.component';
import { RoutingModule } from './routing/routing.module';
import { StatisticsComponent } from './statistics/statistics.component';
import { BoxDetailsComponent } from './box-details/box-details.component';


@NgModule({
  declarations: [
    AppComponent,
    FarmManagementComponent,
    StatisticsComponent,
    BoxDetailsComponent
  ],
  imports: [
    BrowserModule, RoutingModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
