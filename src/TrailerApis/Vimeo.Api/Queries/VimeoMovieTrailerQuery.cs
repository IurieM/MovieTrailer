using MediatR;
using Movie.Common.Queries;
using Movie.Data.Entities;
using System.Collections.Generic;

namespace Vimeo.Api.Queries
{
    public class VimeoMovieTrailerQuery: MovieSearchQuery, IRequest<IEnumerable<MovieTrailer>>
    {
    }
}
