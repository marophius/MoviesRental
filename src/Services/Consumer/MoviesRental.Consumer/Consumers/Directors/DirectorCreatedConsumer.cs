using MassTransit;
using MoviesRental.Core.EventBus.Events;
using MoviesRental.Core.Mediator;
using MoviesRental.Query.Application.Features.Directors.Commands.CreateDirector;

namespace MoviesRental.Consumer.Consumers.Directors
{
    public class DirectorCreatedConsumer : IConsumer<DirectorCreatedEvent>
    {
        private readonly IMediatorHandler _mediator;
        private ILogger<DirectorCreatedConsumer> _logger;

        public DirectorCreatedConsumer(IMediatorHandler mediator, ILogger<DirectorCreatedConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DirectorCreatedEvent> context)
        {
            try
            {
                var @event = context?.Message ?? throw new ArgumentNullException(nameof(context));
                var command = new CreateDirectorCommand(@event.Id, @event.FullName, @event.CreatedAt, @event.UpdatedAt);
                _logger.LogInformation($"Creating director {command.FullName}");

                var response = await _mediator.SendCommandAndReturnBool(command, default);
                if (!response)
                {
                    _logger.LogError($"Something wrong happened during the creation of director {@event.Id}");
                    throw new InvalidOperationException($"Failed to create director {@event.Id}");
                }
                _logger.LogInformation($"Director {@event.Id}  created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while consuming the DirectorCreatedEvent");
                throw;
            }
        }
    }
}
