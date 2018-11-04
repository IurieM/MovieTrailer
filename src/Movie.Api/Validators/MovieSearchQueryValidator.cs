using FluentValidation;
using Movie.Api.Infrastructure;
using Movie.Common.Queries;

namespace Movie.Api.Validators
{
    public class MovieSearchQueryValidator : AbstractValidator<MovieSearchQuery>
    {
        public MovieSearchQueryValidator()
        {
            RuleFor(query => query.Search).NotEmpty().WithErrorCode(Constants.ErrorCodes.Required);
        }
    }
}
