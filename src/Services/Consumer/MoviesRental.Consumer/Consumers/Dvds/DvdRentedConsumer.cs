using MassTransit;
using MoviesRental.Core.EventBus.Events;
using MoviesRental.Core.Mediator;
using MoviesRental.Query.Application.Features.Dvds.Commands.RentDvd;
using MoviesRental.Query.Application.Features.Dvds.Commands.UpdateDvd;

namespace MoviesRental.Consumer.Consumers.Dvds
{
    public class DvdRentedConsumer : IConsumer<DvdRentedEvent>
    {
        private readonly IMediatorHandler _mediator;
        private readonly ILogger<DvdRentedConsumer> _logger;

        public DvdRentedConsumer(IMediatorHandler mediator, ILogger<DvdRentedConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DvdRentedEvent> context)
        {
            try
            {
                var @event = context?.Message ?? throw new ArgumentNullException(nameof(context), "Invalid message");
                if (string.IsNullOrEmpty(@event.Id))
                {
                    _logger.LogError("Invalid message");
                    throw new InvalidOperationException($"Failed to rent dvd {@event.Id}");
                }

                var command = new RentDvdCommand(@event.Id, @event.UpdatedAt);
                _logger.LogInformation($"Renting dvd {@event.Id}");

                var response = await _mediator.SendCommandAndReturnBool(command, default);
                if (!response)
                {
                    _logger.LogError($"Something wrong happened during the rent of dvd {@event.Id}");
                    throw new InvalidOperationException($"Failed to rent dvd {@event.Id}");
                }

                _logger.LogInformation($"Dvd {@event.Id} rented successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while consuming the DvdRentedEvent");
                throw;
            }
        }
    }
}
