import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FarmManagementComponent } from '../farm-management/farm-management.component';
import { StatisticsComponent } from '../statistics/statistics.component';

const routes: Routes = [
  { path: 'farmmanagement', component: FarmManagementComponent},
  {path: 'statistics', component: StatisticsComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule],
  
})
export class RoutingModule { }
