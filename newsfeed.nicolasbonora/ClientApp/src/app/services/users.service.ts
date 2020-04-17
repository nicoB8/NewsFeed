import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { User } from '../entities/User';
import { Observable } from 'rxjs';
import { _throw } from 'rxjs/observable/throw';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UsersService {

  baseUrl: string;
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + "api/users";
  }

  // Create
  post(data): Observable<User> {
    return this.http.post<User>(this.baseUrl, data, { headers: this.headers })
      .pipe(
        catchError(this.error)
      )
  }

  // Read
  get(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
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
