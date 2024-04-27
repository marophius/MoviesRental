using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResponse> SendCommand<TC>(TC command, CancellationToken token) where TC : ICommand
        {
            return (IResponse)await _mediator.Send(command, token);
        }

        public async Task<bool> SendCommandAndReturnBool<TC>(TC command, CancellationToken token) where TC : ICommand
        {
            return (bool) await _mediator.Send(command, token);
        }

        public async Task<IResponse> SendQuery<TQ>(TQ query, CancellationToken token) where TQ : IQuery
        {
            return (IResponse)await _mediator.Send(query, token);
        }
    }
}
