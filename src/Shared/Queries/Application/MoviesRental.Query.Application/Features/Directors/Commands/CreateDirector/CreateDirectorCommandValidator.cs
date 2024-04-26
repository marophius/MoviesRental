using FluentValidation;
using MoviesRental.Core.ValidationMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 60;
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE);
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
                .MinimumLength(MIN_LENGTH).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE)
                .MaximumLength(MAX_LENGTH).WithMessage(ValidationMessages.MAX_LENGTH_ERROR_MESSAGE);
            RuleFor(x => x.CreatedAt)
                .LessThan(DateTime.Now).WithMessage(ValidationMessages.ERROR_MESSAGE);
            RuleFor(x => x.UpdatedAt)
                .LessThan(DateTime.Now).WithMessage(ValidationMessages.ERROR_MESSAGE);
        }
    }
}
