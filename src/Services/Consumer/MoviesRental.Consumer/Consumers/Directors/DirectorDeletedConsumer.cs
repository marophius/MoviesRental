using MassTransit;
using MoviesRental.Core.EventBus.Events;
using MoviesRental.Core.Mediator;
using MoviesRental.Query.Application.Features.Directors.Commands.DeleteDirector;

namespace MoviesRental.Consumer.Consumers.Directors
{
    public class DirectorDeletedConsumer : IConsumer<DirectorDeletedEvent>
    {
        private readonly IMediatorHandler _mediator;
        private ILogger<DirectorDeletedConsumer> _logger;

        public DirectorDeletedConsumer(IMediatorHandler mediator, ILogger<DirectorDeletedConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DirectorDeletedEvent> context)
        {
            try
            {
                var @event = context?.Message ?? throw new ArgumentNullException(nameof(context), "Invalid message");
                var command = new DeleteDirectorCommand(@event.Id);

                _logger.LogInformation($"Removing director {@event.Id}");
                var response = await _mediator.SendCommandAndReturnBool(command, default);

                if (!response)
                    throw new InvalidOperationException($"Something wrong happened during the process of removing director {@event.Id}");

                _logger.LogInformation($"Director {@event.Id} removed successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
