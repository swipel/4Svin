import { Component, OnInit } from '@angular/core';
import { Farm } from "./Models/Farm";
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpService) { }
  
  errorMessage: String;

  farmsList: Farm[];
  farms: Farm[] = [];

  selectedFarm: Number;
  

  ngOnInit() {
    this.http.getFarms().subscribe(
      farms => {
        this.farms = farms;
        this.farmsList = this.farms;
      },
      error => this.errorMessage = <any>error
    );
    
  this.selectedFarm = 1;

   

}





}
