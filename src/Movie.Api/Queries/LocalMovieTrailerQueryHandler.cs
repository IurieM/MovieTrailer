using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Movie.Data.Entities;
using Nest;

namespace Movie.Api.Queries
{
    public class LocalMovieTrailerQueryHandler : IRequestHandler<LocalMovieTrailerQuery, IEnumerable<MovieTrailer>>
    {
        private readonly IElasticClient elasticClient;

        public LocalMovieTrailerQueryHandler(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public async Task<IEnumerable<MovieTrailer>> Handle(LocalMovieTrailerQuery request, CancellationToken cancellationToken)
        {
            var searchResult = await elasticClient.SearchAsync<MovieTrailer>(s =>
            s.Query(q => q.QueryString(d => d.Query(request.Query.Search)))
           .Size(request.Query.ItemsPerPage));

            return searchResult.IsValid ? searchResult.Documents : new List<MovieTrailer>();
        }
    }
}
