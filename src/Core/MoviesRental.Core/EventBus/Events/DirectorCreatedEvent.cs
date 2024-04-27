using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core.EventBus.Events
{
    public record DirectorCreatedEvent(string Id, string FullName, DateTime CreatedAt, DateTime UpdatedAt);
}
