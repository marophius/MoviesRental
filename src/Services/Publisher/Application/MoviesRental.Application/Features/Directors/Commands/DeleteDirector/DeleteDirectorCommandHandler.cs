using MediatR;
using MoviesRental.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.DeleteDirector
{
    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, bool>
    {
        private readonly IDirectorsWriteRepository _repository;

        public DeleteDirectorCommandHandler(IDirectorsWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return false;

            var director = await _repository.GetDirectorWithMovies(request.Id);
            if (director is null || director.Dvds.Any())
                return false;

            return await _repository.Delete(request.Id);
        }
    }
}
