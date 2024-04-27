using MediatR;
using MoviesRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.RentDvd
{
    public class RentDvdCommandHandler : IRequestHandler<RentDvdCommand, RentDvdResponse>
    {
        private readonly IDvdsWriteRepository _repository;

        public RentDvdCommandHandler(IDvdsWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<RentDvdResponse> Handle(RentDvdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return default;

            var dvd = await _repository.Get(request.Id);
            if (dvd is null)
                return default;

            dvd.RentCopy();

            var result = await _repository.Update(dvd);

            if (!result)
                return default;

            return new RentDvdResponse(dvd.Id.ToString(), dvd.UpdatedAt);
        }
    }
}
