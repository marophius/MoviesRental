using MassTransit;
using MoviesRental.Core.EventBus.Events;
using MoviesRental.Core.Mediator;
using MoviesRental.Query.Application.Features.Dvds.Commands.ReturnDvd;

namespace MoviesRental.Consumer.Consumers.Dvds
{
    public class DvdReturnedConsumer : IConsumer<DvdReturnedEvent>
    {
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<DvdReturnedConsumer> _logger;

        public DvdReturnedConsumer(IMediatorHandler mediator, ILogger<DvdReturnedConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DvdReturnedEvent> context)
        {
            try
            {
                var @event = context?.Message ?? throw new ArgumentNullException(nameof(context), "Invalid message");

                if (string.IsNullOrEmpty(@event.Id))
                {
                    _logger.LogError("Invalid message");
                    throw new InvalidOperationException($"Failed to rent dvd {@event.Id}");
                }

                var command = new ReturnDvdCommand(@event.Id, @event.UpdatedAt);
                _logger.LogInformation($"Returning dvd {@event.Id}");

                var response = await _mediator.SendCommandAndReturnBool(command, default);
                if (!response)
                {
                    _logger.LogError($"Something wrong happened during the return of dvd {@event.Id}");
                    throw new InvalidOperationException($"Failed to return dvd {@event.Id}");
                }

                _logger.LogInformation($"Dvd {@event.Id} returned successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while consuming the DvdRentedEvent");
                throw;
            }
        }
    }
}
