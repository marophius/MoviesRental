using MediatR;
using MoviesRental.Query.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Query.Application.Features.Directors.Queries.GetDirector
{
    public class GetDirectorQueryHandler : IRequestHandler<GetDirectorQuery, GetDirectorResponse>
    {
        private readonly IDirectorsQueryRepository _repository;

        public GetDirectorQueryHandler(IDirectorsQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDirectorResponse> Handle(GetDirectorQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FullName))
                return default;

            var director = await _repository.GetByName(request.FullName);
            if (director is null)
                return default;

            return new GetDirectorResponse(director.Id, director.FullName);
        }
    }
}
