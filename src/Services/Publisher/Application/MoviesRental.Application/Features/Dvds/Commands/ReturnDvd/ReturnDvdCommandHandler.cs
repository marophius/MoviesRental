using MediatR;
using MoviesRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.ReturnDvd
{
    public class ReturnDvdCommandHandler : IRequestHandler<ReturnDvdCommand, bool>
    {
        private readonly IDvdsWriteRepository _repository;

        public ReturnDvdCommandHandler(IDvdsWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ReturnDvdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return false;

            var dvd = await _repository.Get(request.Id);
            if (dvd is null)
                return false;

            dvd.ReturnCopy();

            return await _repository.Update(dvd);
        }
    }
}
