import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { MovieSearchQuery } from './movie';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  private fileUrl = environment.api.movie;

  constructor(private http: HttpClient) { }

  get(query: MovieSearchQuery) {
    return this.http.get(`${this.fileUrl}/movie?search=${query.search}`);
  }
}
