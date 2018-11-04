import { Component } from '@angular/core';
import { MovieService } from '../../movie.service';
import { MovieTrailer, MovieSearchQuery } from '../../movie';
import { LoadingBarService } from '../../../shared/components/loading-bar/loading-bar.service';

@Component({
  selector: 'movie-list',
  templateUrl: './movie-list.component.html'
})
export class MovieListComponent {
  movies: MovieTrailer[] = [];

  constructor(private movieService: MovieService, private loadingBarService: LoadingBarService) { }

  onSearch(query: MovieSearchQuery) {
    this.loadingBarService.start();
    this.movieService.get(query).subscribe((movies: MovieTrailer[]) => {
      this.movies = movies;
      this.loadingBarService.stop()
    }, () => this.loadingBarService.stop());
  }
}
