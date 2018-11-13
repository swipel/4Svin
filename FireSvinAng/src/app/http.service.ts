import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { Farm } from './Models/Farm';
import { catchError, tap } from "rxjs/operators";
import { Statistic } from './Models/Statistic';
import { Barn } from './Models/Barn';
import { Box } from './Models/Box';

//This is the service we use to make http calls to our API and return the values as observables to be displayed.
//This service could also be used to provide or site with data from other sources. 
@Injectable({
  providedIn: 'root'
})
export class HttpService {

  //Here we set our root url for the API and inject the httpclient module, which we use to make the calls 
  private ROOT_URL = "https://skole.pietras.dk/api"; 
  constructor(private http: HttpClient) { }


  //Get farms returns an observable of farm arrays. 
  //It calls the API on the root + the extension '/farms' which returns json results of all farms in our database. 
  //The pipe(tap) is a rxjs operator used to handle async data, the tap operator takes the data from the observable and does something with it, before its returned, 
  //in this case we log it.
  //Lastly we have another rxjs operator that checks for errors, and fires the handle(error) function if an error is caught.
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

  getBarnsFromFarm(farmid: number): Observable<Barn[]> {
    return this.http.get<Barn[]>(this.ROOT_URL + "/barns/" + farmid ).pipe(tap(data => console.log('All: ' + JSON.stringify(data))),
    catchError(this.handleError)
    );
  }

  getBoxesFromBarnAndFarm(farmid: number, barnNumber: number): Observable<Box[]> {
    return this.http.get<Box[]>(this.ROOT_URL + "/boxes/" + farmid + "/" + barnNumber ).pipe(tap(data => console.log('All: ' + JSON.stringify(data))),
    catchError(this.handleError)
    );
  }

  getBoxFromBarnAndFarm(farmid: number, barnNumber: number, boxNumber: number): Observable<Box[]> {
    return this.http.get<Box[]>(this.ROOT_URL + "/boxes/" + farmid + "/" + barnNumber + "/" + boxNumber ).pipe(tap(data => console.log('All: ' + JSON.stringify(data))),
    catchError(this.handleError)
    );
  }

  feed(farmid: number): Observable<Farm> {
    console.log(this.ROOT_URL + "/farms/" + farmid + "/feed");
    return this.http.get<Farm>(this.ROOT_URL + "/farms/" + farmid + "/feed").pipe(tap(data => console.log('All: ' + JSON.stringify(data))),
    catchError(this.handleError)
    ); 
    
  }

  //error handeler (LÆS IGEN )
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
