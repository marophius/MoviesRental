using FluentValidation;
using MoviesRental.Core.ValidationMessages;
using MoviesRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage(ValidationMessages.ERROR_MESSAGE);
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
                .MinimumLength(Director.MIN_LENGTH).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE);
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
                .MinimumLength(Director.MIN_LENGTH).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE);
        }
    }
}
