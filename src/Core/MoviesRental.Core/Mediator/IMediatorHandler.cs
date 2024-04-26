using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<IResponse> SendCommand<TC>(TC command) where TC : ICommand;
        Task<IResponse> SendQuery<TQ>(TQ query) where TQ : IQuery;
    }
}
