using MediatR;
using Movie.Common.Queries;
using Movie.Data.Entities;
using System.Collections.Generic;

namespace Youtube.Api.Queries
{
    public class YoutubeMovieTrailerQuery : MovieSearchQuery, IRequest<IEnumerable<MovieTrailer>>
    {
    }
}
