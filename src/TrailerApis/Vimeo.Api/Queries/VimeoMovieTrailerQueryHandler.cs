using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Movie.Data.Entities;
using Block.Http;
using Vimeo.Api.Settings;
using Microsoft.Extensions.Options;
using Vimeo.Api.Models;
using System.Linq;

namespace Vimeo.Api.Queries
{
    public class VimeoMovieTrailerQueryHandler : IRequestHandler<VimeoMovieTrailerQuery, IEnumerable<MovieTrailer>>
    {
        private readonly IHttpClient httpClient;
        private readonly IOptions<VimeoSettings> vimeoSettings;
        private const string Vimeo = "vimeo";

        public VimeoMovieTrailerQueryHandler(IHttpClient httpClient, IOptions<VimeoSettings> vimeoSettings)
        {
            this.httpClient = httpClient;
            this.vimeoSettings = vimeoSettings;
        }

        public async Task<IEnumerable<MovieTrailer>> Handle(VimeoMovieTrailerQuery request, CancellationToken cancellationToken)
        {
            var searchResult = await httpClient
                .GetAsync<SearchResultModel>(vimeoSettings.Value.ApiUrl +
                $"?per_page={request.ItemsPerPage}&query={request.Search}",
                vimeoSettings.Value.AuthorizationToken, vimeoSettings.Value.AuthorizationMethod);

            return searchResult?.Data.Select(item => new MovieTrailer() { Link = item.Link, Title = item.Name, Provider = Vimeo });
        }
    }
}
