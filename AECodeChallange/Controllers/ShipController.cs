using AE.Application.CommonModels;
using AE.Application.Modules.Ship.Commands;
using AE.Application.Modules.Ship.Commands.CommandModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AECodeChallange.Controllers
{
    [Route("api/ship")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private IMediator _mediator;
        public ShipController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("create")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateShipAsync(CreateShipCommand createShipCommand)
        {
            var result = await _mediator.Send(createShipCommand);
            return Ok(result);
        }

        [HttpPost("update")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateShipAsync(UpdateShipCommand updateShipCommand)
        {
            var result = await _mediator.Send(updateShipCommand);
            return Ok(result);
        }
    }
}
