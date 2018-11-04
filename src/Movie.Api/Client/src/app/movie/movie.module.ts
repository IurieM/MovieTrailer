import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { MovieService } from './movie.service';
import { MovieRoutingModule } from './movie-route.module';
import { MovieListComponent } from './components/movie-list/movie-list.component';
import { SearchMovieComponent } from './components/search/search-movie.component';

@NgModule({
  imports: [
    SharedModule,
    MovieRoutingModule,
  ],
  providers: [MovieService],
  declarations: [
    MovieListComponent,
    SearchMovieComponent
  ]
})
export class MovieModule { }
