import { Component, OnInit } from '@angular/core';
import { Farm } from "./Models/Farm";
import { HttpService } from './http.service';
import { Observable } from 'rxjs';
import { Globals } from './Globals';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private http: HttpService, private gl: Globals) { }
  
  errorMessage: String;

  
  farms: Farm[];

  

  ngOnInit() {
    this.http.getFarms().subscribe(
      farms => this.farms = farms,
      error => this.errorMessage = <any>error
    );
    
}



  





}
