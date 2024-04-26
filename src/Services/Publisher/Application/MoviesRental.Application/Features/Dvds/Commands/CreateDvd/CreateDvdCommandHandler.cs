using MediatR;
using MoviesRental.Application.Contracts;
using MoviesRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.CreateDvd
{
    public class CreateDvdCommandHandler : IRequestHandler<CreateDvdCommand, CreateDvdResponse>
    {
        private readonly IDvdsWriteRepository _repository;
        private readonly CreateDvdCommandValidator _validator;

        public CreateDvdCommandHandler(IDvdsWriteRepository repository, CreateDvdCommandValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateDvdResponse> Handle(CreateDvdCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return default;

            var dvd = new Dvd(request.Title, request.Genre, request.Published, request.Copies, request.DirectorId);

            var result = await _repository.Create(dvd);
            if (!result)
                return default;

            return new CreateDvdResponse(dvd.Id.ToString(),
                dvd.Title,
                dvd.Genre.ToString(),
                dvd.Published,
                dvd.Available,
                dvd.Copies,
                dvd.DirectorId.ToString(),
                dvd.CreatedAt,
                dvd.UpdatedAt);
        }
    }
}
