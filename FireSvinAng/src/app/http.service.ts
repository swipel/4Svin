import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { Farm } from './Models/Farm';
import { catchError, tap } from "rxjs/operators";
import { Statistic } from './Models/Statistic';


@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private ROOT_URL = "https://skole.pietras.dk/api"; 
  constructor(private http: HttpClient) { }

  getFarms(): Observable<Farm[]> 
  {
    return this.http.get<Farm[]>(this.ROOT_URL + "/farms").pipe(tap(data => console.log('All: ' + JSON.stringify(data))),
    catchError(this.handleError)
    );
  }

  getStatistics(farmid: number) {
    return this.http.get<Statistic[]>(this.ROOT_URL + "/boxes/" + farmid + "/statistics").pipe(tap(data => console.log('All: ' + JSON.stringify(data))),
    catchError(this.handleError)
    );
  }

  private handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {
      errorMessage = 'An error occurred: ${err.error.message}';
    }
    else {
      errorMessage = 'Server returned code: ${err.status}, error message is: ${err.message}';
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }

}
