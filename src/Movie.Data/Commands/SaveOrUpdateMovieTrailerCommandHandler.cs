using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Nest;
using Movie.Data.Entities;
using System.Linq;

namespace Movie.Data.Commands
{
    public class SaveOrUpdateMovieTrailerCommandHandler : IRequestHandler<SaveOrUpdateMovieTrailerCommand, IBulkResponse>
    {
        private readonly IElasticClient elasticClient;

        public SaveOrUpdateMovieTrailerCommandHandler(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public async Task<IBulkResponse> Handle(SaveOrUpdateMovieTrailerCommand request, CancellationToken cancellationToken)
        {
            if (!request.MovieTrailers.Any())
            {
                return null;
            }
            var descriptor = new BulkDescriptor();

            foreach (var movieTrailer in request.MovieTrailers)
            {
                descriptor.Index<MovieTrailer>(op => op.Document(movieTrailer));
            }

            var response = await elasticClient.BulkAsync(descriptor);
            return response;
        }
    }
}
