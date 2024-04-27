﻿using MoviesRental.Core.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Application.Features.Dvds.Commands.RentDvd
{
    public record RentDvdResponse(string Id, DateTime UpdatedAt) : IResponse;
}
