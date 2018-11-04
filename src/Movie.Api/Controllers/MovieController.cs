using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Movie.Api.Queries;
using Movie.Common.Queries;
using System.Linq;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator mediator;

        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]MovieSearchQuery query)
        {
            var movieTrailers = await mediator.Send(new LocalMovieTrailerQuery(query));
            if (movieTrailers.Any())
            {
                return Ok(movieTrailers);
            }
            movieTrailers = await mediator.Send(new ExternalMovieTrailerQuery(query));
            return Ok(movieTrailers);
        }
    }
}
