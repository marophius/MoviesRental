using MediatR;
using MoviesRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.RentDvd
{
    public class RentDvdCommandHandler : IRequestHandler<RentDvdCommand, bool>
    {
        private readonly IDvdsWriteRepository _repository;

        public RentDvdCommandHandler(IDvdsWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RentDvdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return false;

            var dvd = await _repository.Get(request.Id);
            if (dvd is null)
                return false;

            dvd.RentCopy();

            return await _repository.Update(dvd);
        }
    }
}
