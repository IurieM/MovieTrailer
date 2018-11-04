using MediatR;
using System.Collections.Generic;
using Movie.Data.Entities;
using Movie.Common.Queries;

namespace Movie.Api.Queries
{
    public class ExternalMovieTrailerQuery : IRequest<IEnumerable<MovieTrailer>>
    {
        public MovieSearchQuery Query { get;}

        public ExternalMovieTrailerQuery(MovieSearchQuery query)
        {
            Query = query;
        }
    }
}
