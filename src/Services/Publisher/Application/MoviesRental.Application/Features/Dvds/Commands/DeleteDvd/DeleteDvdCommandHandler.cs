using MediatR;
using MoviesRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.DeleteDvd
{
    public class DeleteDvdCommandHandler : IRequestHandler<DeleteDvdCommand, DeleteDvdResponse>
    {
        private readonly IDvdsWriteRepository _repository;

        public DeleteDvdCommandHandler(IDvdsWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteDvdResponse> Handle(DeleteDvdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return default;

            var dvd = await _repository.Get(request.Id);
            if (dvd is null)
                return default;

            dvd.DeleteDvd();

            var result = await _repository.Update(dvd);
            if (!result)
                return default;

            return new DeleteDvdResponse(dvd.Id.ToString(), (DateTime)dvd.DeletedAt);

        }
    }
}
