import { Component, EventEmitter, Output } from '@angular/core';
import { MovieSearchQuery } from '../../movie';

@Component({
    selector: 'search-movie',
    templateUrl: 'search-movie.component.html'
})
export class SearchMovieComponent {
    searchQuery: MovieSearchQuery;
    @Output() onSearch = new EventEmitter<MovieSearchQuery>();
    constructor() {
        this.searchQuery = new MovieSearchQuery();
    }

    search() {
        this.onSearch.emit(this.searchQuery);
    }

    clear() {
        this.searchQuery.search = '';
    }
}
