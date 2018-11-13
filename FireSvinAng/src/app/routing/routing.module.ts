import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FarmManagementComponent } from '../farm-management/farm-management.component';
import { StatisticsComponent } from '../statistics/statistics.component';
import { BoxDetailsComponent } from '../box-details/box-details.component';

const routes: Routes = [
  { path: 'farmmanagement', component: FarmManagementComponent},
  {path: 'statistics', component: StatisticsComponent},
  {path: 'detail/:farmId/:barnNumber/:boxNumber', component: BoxDetailsComponent} 
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  
})
export class RoutingModule { }
