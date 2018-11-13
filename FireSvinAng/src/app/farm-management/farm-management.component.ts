import { Component, OnInit, AfterViewInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Observable } from 'rxjs';
import { Barn } from '../Models/Barn';
import { Farm } from '../Models/Farm';
import { Globals } from '../Globals';
import { Box } from '../Models/Box';


@Component({
  selector: 'app-farm-management',
  templateUrl: './farm-management.component.html',
  styleUrls: ['./farm-management.component.scss']
})
export class FarmManagementComponent implements OnInit, AfterViewInit {

  constructor(private http: HttpService, private gl: Globals) { }
  errorMessage: string;
  
  currentBarn: number = 1;
  currentBox: number;
  boxes: Box[];
  barns: Barn[];
  selectedBox: Box;
  

  ngOnInit() {
    
  }

  ngAfterViewInit() {
    this.http.getBarnsFromFarm(this.gl.currentFarm).subscribe(
      barns => 
      this.barns = barns,
      error => this.errorMessage = <any>error,
    )
    this.getBoxesFromBarn();
  }

  getBoxesFromBarn() {
    this.http.getBoxesFromBarnAndFarm(this.gl.currentFarm, this.currentBarn).subscribe(
      boxes => 
      this.boxes = boxes,
      error => this.errorMessage = <any>error,
    )
  }

 
  onSelect(box: Box): void {
    this.selectedBox = box;
  }
  

  
  




}
