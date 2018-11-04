using System.Threading.Tasks;
using Block.BackgroudService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Data.Commands;
using Vimeo.Api.Queries;

namespace Youtube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IBackgroundTaskQueue queue;

        public MovieController(IMediator mediator, IBackgroundTaskQueue queue)
        {
            this.mediator = mediator;
            this.queue = queue;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]VimeoMovieTrailerQuery query)
        {
            var movieList = await mediator.Send(query);
            queue.QueueBackgroundWorkItem((token) => mediator.Send(new SaveOrUpdateMovieTrailerCommand(movieList), token));
            return Ok(movieList);
        }
    }
}
