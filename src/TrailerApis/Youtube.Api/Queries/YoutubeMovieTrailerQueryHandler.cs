
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Movie.Data.Entities;
using Block.Http;
using Microsoft.Extensions.Options;
using Youtube.Api.Settings;
using Youtube.Api.Models;
using System.Linq;

namespace Youtube.Api.Queries
{
    public class YoutubeMovieTrailerQueryHandler : IRequestHandler<YoutubeMovieTrailerQuery, IEnumerable<MovieTrailer>>
    {
        private readonly IHttpClient httpClient;
        private readonly IOptions<YoutubeSettings> youtubeSettings;
        private const string Youtube = "youtube";

        public YoutubeMovieTrailerQueryHandler(IHttpClient httpClient, IOptions<YoutubeSettings> youtubeSettings)
        {
            this.httpClient = httpClient;
            this.youtubeSettings = youtubeSettings;
        }

        public async Task<IEnumerable<MovieTrailer>> Handle(YoutubeMovieTrailerQuery request, CancellationToken cancellationToken)
        {
            var searchResult = await httpClient
                .GetAsync<SearchResultModel>(youtubeSettings.Value.ApiUrl +
                $"&maxResults={request.ItemsPerPage}&q={request.Search}");

            return searchResult.Items.Select(item => new MovieTrailer()
            {
                Link = string.Concat(youtubeSettings.Value.WatchUrl, item.Id.VideoId),
                Title = item.Snippet.Title,
                Provider = Youtube
            });
        }
    }
}
