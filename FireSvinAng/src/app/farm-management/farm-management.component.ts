import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Observable } from 'rxjs';
import { Barn } from '../Models/Barn';
import { Farm } from '../Models/Farm';

@Component({
  selector: 'app-farm-management',
  templateUrl: './farm-management.component.html',
  styleUrls: ['./farm-management.component.scss']
})
export class FarmManagementComponent implements OnInit {

  constructor(private http: HttpService) { }

  

  CurrentFarms: Observable<Farm>;

  ngOnInit() {
   //   this.getFarms();
  }

  //getFarms(): void {
   // this.CurrentFarms = this.http.getFarms();
  //}




}
