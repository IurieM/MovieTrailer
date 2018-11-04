using MediatR;
using System.Collections.Generic;
using Movie.Data.Entities;
using Movie.Common.Queries;

namespace Movie.Api.Queries
{
    public class LocalMovieTrailerQuery : IRequest<IEnumerable<MovieTrailer>>
    {
        public MovieSearchQuery Query { get; }

        public LocalMovieTrailerQuery(MovieSearchQuery query)
        {
            Query = query;
        }
    }
}
