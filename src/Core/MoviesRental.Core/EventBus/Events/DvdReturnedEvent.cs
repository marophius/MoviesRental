using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.EventBus.Events
{
    public record DvdReturnedEvent(string Id, DateTime UpdatedAt);
}
