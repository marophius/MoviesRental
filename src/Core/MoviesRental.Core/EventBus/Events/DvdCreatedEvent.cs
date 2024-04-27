using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.EventBus.Events
{
    public record DvdCreatedEvent(string Id,
        string Title,
        string Genre,
        DateTime Published,
        bool Available,
        int Copies,
        string DirectorId,
        DateTime CreatedAt,
        DateTime UpdatedAt);
}
