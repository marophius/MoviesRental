using MassTransit;
using Microsoft.AspNetCore.Mvc;
using MoviesRental.Api.Cache;
using MoviesRental.Application.Features.Dvds.Commands.CreateDvd;
using MoviesRental.Application.Features.Dvds.Commands.DeleteDvd;
using MoviesRental.Application.Features.Dvds.Commands.RentDvd;
using MoviesRental.Application.Features.Dvds.Commands.ReturnDvd;
using MoviesRental.Application.Features.Dvds.Commands.UpdateDvd;
using MoviesRental.Core.EventBus.Events;
using MoviesRental.Core.Mediator;
using MoviesRental.Query.Application.Features.Dvds.Queries.GetDvd;
using System.Net;

namespace MoviesRental.Api.Controllers
{
    public class DvdsController : ApiController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IPublishEndpoint _publishEndPoint;
        private readonly ICacheRepository _cacheRepository;

        public DvdsController(IMediatorHandler mediator, IPublishEndpoint publishEndPoint, ICacheRepository cacheRepository)
        {
            _mediator = mediator;
            _publishEndPoint = publishEndPoint;
            _cacheRepository = cacheRepository;
        }

        [HttpGet("[action]/{title}", Name = "GetDvd")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetDvd([FromRoute] string title)
        {
            var response = await _cacheRepository.Get(title);

            if (response is not null)
                return CustomResponse((int)HttpStatusCode.OK, true, response);

            var query = new GetDvdQuery(title);

            response = (GetDvdResponse)await _mediator.SendQuery(query, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.NotFound, false);

            await _cacheRepository.Update(response);

            return CustomResponse((int)HttpStatusCode.OK, true, response);
        }

        [HttpPost("CreateDvd")]
        [ProducesResponseType(typeof(CreateDvdResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreateDvdResponse>> CreateDvd(
            [FromBody] CreateDvdCommand command)
        {
            var response = (CreateDvdResponse) await _mediator.SendCommand(command, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.BadRequest, false);

            var @event = new DvdCreatedEvent(
                response.Id,
                response.Title,
                response.Genre,
                response.Published,
                response.Available,
                response.Copies,
                response.DirectorId,
                response.CreatedAt,
                response.UpdatedAt);

            await _publishEndPoint.Publish(@event);

            return CustomResponse((int)HttpStatusCode.Created, true, response);
        }

        [HttpPut("UpdateDvd")]
        [ProducesResponseType(typeof(UpdateDvdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<UpdateDvdResponse>> UpdateDvd(
            [FromBody] UpdateDvdCommand command)
        {
            var response = (UpdateDvdResponse) await _mediator.SendCommand(command, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.BadRequest, false);

            var @event = new DvdUpdatedEvent(
                response.Id,
                response.Title,
                response.Genre,
                response.Published,
                response.Copies,
                response.DirectorId,
                response.UpdatedAt);

            await _publishEndPoint.Publish(@event);
            return CustomResponse((int)HttpStatusCode.OK, true, response);
        }

        [HttpPut("RentDvd/{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> RentDvd([FromRoute] Guid id)
        {
            var command = new RentDvdCommand(id);
            var response = (RentDvdResponse) await _mediator.SendCommand(command, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.BadRequest, false);

            var @event = new DvdRentedEvent(id.ToString(), response.UpdatedAt);
            await _publishEndPoint.Publish(@event);

            return CustomResponse((int)HttpStatusCode.OK, true, response);
        }

        [HttpPut("ReturnDvd/{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> ReturnDvd([FromRoute] Guid id)
        {
            var command = new ReturnDvdCommand(id);
            var response = (ReturnDvdResponse) await _mediator.SendCommand(command, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.BadRequest, false);

            var @event = new DvdReturnedEvent(id.ToString(), response.UpdatedAt);
            await _publishEndPoint.Publish(@event);

            return CustomResponse((int)HttpStatusCode.OK, true, response);
        }

        [HttpDelete("DeleteDvd/{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteDvd(
            [FromRoute] Guid id)
        {
            var command = new DeleteDvdCommand(id);
            var response = (DeleteDvdResponse)await _mediator.SendCommand(command, HttpContext.RequestAborted);

            if (response is null)
                return CustomResponse((int)HttpStatusCode.BadRequest, false);

            var @event = new DvdDeletedEvent(id.ToString(), response.DeletedAt);
            await _publishEndPoint.Publish(@event);

            return CustomResponse((int)HttpStatusCode.OK, true);
        }
    }
}
