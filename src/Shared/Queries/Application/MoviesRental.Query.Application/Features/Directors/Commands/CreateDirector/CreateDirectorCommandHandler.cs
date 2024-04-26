using MediatR;
using MoviesRental.Query.Application.Contracts;
using MoviesRental.Query.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, bool>
    {
        private readonly IDirectorsQueryRepository _repository;
        private readonly CreateDirectorCommandValidator _validator;

        public CreateDirectorCommandHandler(
            IDirectorsQueryRepository repository, 
            CreateDirectorCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if(!validationResult.IsValid)
                return false;

            var director = await _repository.Get(request.Id);
            if (director is not null)
                return false;

            director = new Director { Id = request.Id, FullName = request.FullName };

            var result = await _repository.Create(director);
            if(result is null)
                return false;

            return true;
        }
    }
}
