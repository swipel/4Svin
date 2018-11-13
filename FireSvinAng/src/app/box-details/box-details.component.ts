import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';
import { Box } from '../Models/Box';
import { map } from 'rxjs/operators';
 

@Component({
  selector: 'app-box-details',
  templateUrl: './box-details.component.html',
  styleUrls: ['./box-details.component.scss']
})
export class BoxDetailsComponent implements OnInit, AfterViewInit {
  
  errorMessage: string;

  constructor(private http: HttpService, private route: ActivatedRoute) { }

 


  boxes: Box[];
  
  box: Box;

  

  ngOnInit() {
    
    
  }

  ngAfterViewInit(): void {
    this.getBox();
  }

  getBox(): void {
    const farmid = +this.route.snapshot.paramMap.get('farmId');
    const barnNumber = +this.route.snapshot.paramMap.get('barnNumber');
    const boxNumber = +this.route.snapshot.paramMap.get('boxNumber');
    

   this.http.getBoxFromBarnAndFarm(farmid, barnNumber, boxNumber).subscribe(boxes => 
   this.boxes = boxes);
    
  }

  
  
}
