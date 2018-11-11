import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { Farm } from './Models/Farm';
import { catchError, tap } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private ROOT_URL = "https://skole.pietras.dk/api/farms"; 
  constructor(private http: HttpClient) { }

  getFarms(): Observable<Farm[]> 
  {
    return this.http.get<Farm[]>(this.ROOT_URL).pipe(tap(data => console.log('All: ' + JSON.stringify(data))),
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
