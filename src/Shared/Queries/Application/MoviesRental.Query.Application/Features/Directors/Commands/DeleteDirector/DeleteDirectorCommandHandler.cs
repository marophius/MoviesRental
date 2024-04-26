using MediatR;
using MoviesRental.Query.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Directors.Commands.DeleteDirector
{
    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, bool>
    {
        private readonly IDirectorsQueryRepository _repository;

        public DeleteDirectorCommandHandler(IDirectorsQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
                return false;

            var director = await _repository.Get(request.Id);
            if (director is null)
                return false;

            return await _repository.Delete(request.Id);
        }
    }
}
