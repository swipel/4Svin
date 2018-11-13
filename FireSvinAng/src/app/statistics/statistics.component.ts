import { Component, OnInit, AfterViewInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Globals } from '../Globals';
import { Statistic } from '../Models/Statistic';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit, AfterViewInit {
  
  
  errorMessage: string;

  constructor(private http: HttpService, private gl: Globals) { }

  stats: Statistic[];


  ngOnInit() {
    
  }

  ngAfterViewInit(): void {
    this.loadStatsFromSelectedFarm();
  }

  loadStatsFromSelectedFarm() {
    this.http.getStatistics(this.gl.currentFarm).subscribe(
      stats => 
      this.stats = stats,
      error => this.errorMessage = <any>error,
    )
  }



}
