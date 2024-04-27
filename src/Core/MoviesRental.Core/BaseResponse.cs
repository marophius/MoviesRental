using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRental.Core
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
