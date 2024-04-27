using MassTransit;
using MoviesRental.Core.EventBus.Events;
using MoviesRental.Core.Mediator;
using MoviesRental.Query.Application.Features.Dvds.Commands.DeleteDvd;

namespace MoviesRental.Consumer.Consumers.Dvds
{
    public class DvdDeletedConsumer : IConsumer<DvdDeletedEvent>
    {
        private readonly ILogger<DvdDeletedConsumer> _logger;
        private readonly IMediatorHandler _mediator;

        public DvdDeletedConsumer(ILogger<DvdDeletedConsumer> logger, IMediatorHandler mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<DvdDeletedEvent> context)
        {
            try
            {
                var @event = context?.Message ?? throw new ArgumentNullException(nameof(context), "Invalid message");

                if (string.IsNullOrEmpty(@event.Id) || @event.DeletedAt > DateTime.Now)
                {
                    _logger.LogError("Invalid message");
                    throw new InvalidOperationException($"Failed to create dvd {@event.Id}");
                }

                var command = new DeleteDvdCommand(@event.Id, @event.DeletedAt);
                _logger.LogInformation($"Deleting dvd {@event.Id}");

                var response = await _mediator.SendCommandAndReturnBool(command, default);
                if (!response)
                {
                    _logger.LogError($"Something wrong happened during the delete of dvd {@event.Id}");
                    throw new InvalidOperationException($"Failed to delete dvd {@event.Id}");
                }

                _logger.LogInformation($"Dvd {@event.Id} deleted successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while consuming the DvdDeletedEvent");
                throw;
            }
        }
    }
}
