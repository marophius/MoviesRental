using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;
using MoviesRental.Core.DomainObjects;

namespace MoviesRental.Api.Setup
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            this.logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            (int statusCode, string errorMessage) = exception switch
            {
                ArgumentNullException argumentException => (500, argumentException.Message),
                DomainException domainException => (500, domainException.Message),
                SqlException sqlException => (500, sqlException.Message),
                ValidationException validationException => (500, validationException.Message),
                _ => (500, "Something went wrong")
            };

            logger.LogError(exception, exception.Message);
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(errorMessage, cancellationToken);
            return true;
        }
    }
}
