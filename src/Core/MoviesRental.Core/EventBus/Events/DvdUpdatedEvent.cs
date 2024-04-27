using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.EventBus.Events
{
    public record DvdUpdatedEvent(string Id,
        string Title,
        string Genre,
        DateTime Published,
        int Copies,
        string DirectorId,
        DateTime UpdatedAt);
}
