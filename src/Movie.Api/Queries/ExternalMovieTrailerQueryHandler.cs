using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Movie.Data.Entities;
using Microsoft.Extensions.Options;
using Movie.Api.Settings;
using Block.Http;
using System.Linq;

namespace Movie.Api.Queries
{
    public class ExternalMovieTrailerQueryHandler : IRequestHandler<ExternalMovieTrailerQuery, IEnumerable<MovieTrailer>>
    {
        private readonly IHttpClient httpClient;
        private readonly IOptions<MovieApiSettings> apiSettings;

        public ExternalMovieTrailerQueryHandler(IHttpClient httpClient, IOptions<MovieApiSettings> apiSettings)
        {
            this.httpClient = httpClient;
            this.apiSettings = apiSettings;
        }

        public async Task<IEnumerable<MovieTrailer>> Handle(ExternalMovieTrailerQuery request, CancellationToken cancellationToken)
        {
            var tasks = apiSettings.Value.ApiUrls.Select(url => httpClient.GetAsync<IEnumerable<MovieTrailer>>(
                    $"{url}?Search={request.Query.Search}&ItemsPerPage={request.Query.ItemsPerPage}")
                );


            var movieTrailes = await Task.WhenAll(tasks);

            return movieTrailes.SelectMany(movies => movies);
        }
    }
}
