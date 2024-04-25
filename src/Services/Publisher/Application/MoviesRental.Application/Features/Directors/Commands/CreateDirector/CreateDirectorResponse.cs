﻿using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Directors.Commands.CreateDirector
{
    public record CreateDirectorResponse(string Id,
        string FullName,
        DateTime CreatedAt,
        DateTime UpdatedAt) : IResponse;
}
