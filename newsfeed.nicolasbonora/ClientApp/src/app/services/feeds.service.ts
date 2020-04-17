import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { _throw } from 'rxjs/observable/throw';
import { catchError } from 'rxjs/operators';
import { Post } from '../entities/Post';

@Injectable()
export class FeedsService {

  baseUrl: string;
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + "api/feeds";
  }
  
  // Read
  subscribeToFeed(id, userId): Observable<boolean> {
    let apiUrl = this.baseUrl + "/" + id + "/subscribe/" + userId;
    return this.http.get<boolean>(apiUrl);
  }

  // Handle Errors 
  error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return _throw(errorMessage);
  }
  
}
