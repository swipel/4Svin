import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Observable } from 'rxjs';
import { Barn } from '../Models/Barn';
import { Farm } from '../Models/Farm';
import { Globals } from '../Globals';


@Component({
  selector: 'app-farm-management',
  templateUrl: './farm-management.component.html',
  styleUrls: ['./farm-management.component.scss']
})
export class FarmManagementComponent implements OnInit {

  constructor(private http: HttpService, private gl: Globals) { }
  errorMessage: string;
  
  
  farms: Farm[];
  farm: Farm;
  barns: Barn[];
 
  

  ngOnInit() {
    this.http.getFarms().subscribe(
      farms => 
      this.farms = farms,
      error => this.errorMessage = <any>error,
    )

    
    

  }

 

  

  
  




}
