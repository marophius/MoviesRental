using MediatR;
using MoviesRental.Query.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Dvds.Commands.ReturnDvd
{
    public class ReturnDvdCommandHandler : IRequestHandler<ReturnDvdCommand, bool>
    {
        private readonly IDvdsQueryRepository _repository;

        public ReturnDvdCommandHandler(IDvdsQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ReturnDvdCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id) || request.UpdatedAt > DateTime.Now)
                return false;

            var dvd = await _repository.Get(request.Id);
            if(dvd is null)
                return false;

            dvd.Copies += 1;

            return await _repository.Update(dvd);
        }
    }
}
