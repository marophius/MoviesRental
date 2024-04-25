using MediatR;
using MoviesRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.UpdateDirector
{
    public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, UpdateDirectorResponse>
    {
        private readonly IDirectorsWriteRepository _repository;
        private readonly UpdateDirectorCommandValidator _validator;

        public UpdateDirectorCommandHandler(IDirectorsWriteRepository repository, UpdateDirectorCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateDirectorResponse> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return default;

            var director = await _repository.Get(request.Id);
            if (director is null)
                return default;

            director.UpdateName(request.Name);
            director.UpdateSurname(request.Surname);

            var result = await _repository.Update(director);
            if (!result)
                return default;

            return new UpdateDirectorResponse(director.Id.ToString(), director.FullName(), director.UpdatedAt);
        }
    }
}
