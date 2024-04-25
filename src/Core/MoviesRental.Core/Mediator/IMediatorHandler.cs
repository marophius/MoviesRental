using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<IResponse> Send<TC>(TC command) where TC : ICommand;
    }
}
