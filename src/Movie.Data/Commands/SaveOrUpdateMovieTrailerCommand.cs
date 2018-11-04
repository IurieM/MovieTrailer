using MediatR;
using Movie.Data.Entities;
using System.Collections.Generic;

namespace Movie.Data.Commands
{
    public class SaveOrUpdateMovieTrailerCommand : IRequest<Nest.IBulkResponse>
    {
        public IEnumerable<MovieTrailer> MovieTrailers { get; }

        public SaveOrUpdateMovieTrailerCommand(IEnumerable<MovieTrailer> MovieTrailers)
        {
            this.MovieTrailers = MovieTrailers;
        }
    }
}
