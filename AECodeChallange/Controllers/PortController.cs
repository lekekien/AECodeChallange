using AE.Application.CommonModels;
using AE.Application.Modules.PortModule.Queries.Models;
using AE.Application.Modules.PortModule.Queries.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AECodeChallange.Controllers
{
    [Route("api/port")]
    public class PortController : ControllerBase
    {
        private IMediator _mediator;
        public PortController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get infomation of closest port from a ship 
        /// </summary>
        /// <param name="shipId"></param>
        /// <returns></returns>
        [HttpGet("get-closest-port/{shipId}")]
        [ProducesResponseType(typeof(ClosestPortModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClosetPortAsync(Guid shipId)
        {
            var result = await _mediator.Send(new GetClosestPortQuery(shipId));
            return Ok(result);
        }
    }

}