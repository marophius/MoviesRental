using MediatR;
using MoviesRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.UpdateDvd
{
    public class UpdateDvdCommandHandler : IRequestHandler<UpdateDvdCommand, UpdateDvdResponse>
    {
        private readonly IDvdsWriteRepository _repository;
        private readonly UpdateDvdCommandValidator _validator;

        public UpdateDvdCommandHandler(
            IDvdsWriteRepository repository, 
            UpdateDvdCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateDvdResponse> Handle(UpdateDvdCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
                return default;

            var dvd = await _repository.Get(request.Id);
            if (dvd is null)
                return default;

            dvd.UpdateTitle(request.Title);
            dvd.UpdateCopies(request.Copies);
            dvd.UpdatePublishedDate(request.Published);
            dvd.UpdateGenre(request.Genre);
            dvd.UpdateDirector(request.DirectorId);

            var result = await _repository.Update(dvd);
            if (!result)
                return default;

            return new UpdateDvdResponse(dvd.Id.ToString(),
                dvd.Title,
                dvd.Genre.ToString(),
                dvd.Published,
                dvd.Copies,
                dvd.DirectorId.ToString(),
                dvd.UpdatedAt);

        }
    }
}
