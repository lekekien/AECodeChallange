using AE.Application.Modules.Ship.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AECodeChallange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        IMediator _mediator;
        public ShipController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateShipCommand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateShipAsync(CreateShipCommand createShipCommand)
        {
            var result = await _mediator.Send(createShipCommand);
            return Ok(result);
        }
    }
}
