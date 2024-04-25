using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MoviesRental.Core.ValidationMessages;
using MoviesRental.Domain.Entities;

namespace MoviesRental.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
                .MinimumLength(Director.MIN_LENGTH).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE)
                .MaximumLength(Director.MAX_LENGTH).WithMessage(ValidationMessages.MAX_LENGTH_ERROR_MESSAGE);
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
                .MinimumLength(Director.MIN_LENGTH).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE)
                .MaximumLength(Director.MAX_LENGTH).WithMessage(ValidationMessages.MAX_LENGTH_ERROR_MESSAGE);
        }
    }
}
