import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { _throw } from 'rxjs/observable/throw';
import { catchError } from 'rxjs/operators';
import { Post } from '../entities/Post';

@Injectable()
export class PostsService {

  baseUrl: string;
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + "api/posts";
  }

  // Create
  post(data): Observable<Post> {
    return this.http.post<Post>(this.baseUrl, data, { headers: this.headers })
      .pipe(
        catchError(this.error)
      )
  }

  // Read
  getByUserId(userId): Observable<Post[]> {
    let apiUrl = this.baseUrl + "/User/" + userId;
    return this.http.get<Post[]>(apiUrl);
  }

  get(): Observable<Post[]> {
    return this.http.get<Post[]>(this.baseUrl);
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
