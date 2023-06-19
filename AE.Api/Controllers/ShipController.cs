using AE.Application.CommonModels;
using AE.Application.Modules.ShipModule.Commands.CommandModels;
using AE.Application.Modules.ShipModule.Queries.Models;
using AE.Application.Modules.ShipModule.Queries.ResponseModels;
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
        /// <summary>
        /// Create a new ship
        /// </summary>
        /// <param name="createShipCommand"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateShipAsync(CreateShipCommand createShipCommand)
        {
            var result = await _mediator.Send(createShipCommand);
            return Ok(result);
        }

        /// <summary>
        /// Update a ship exist
        /// </summary>
        /// <param name="updateShipCommand"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateShipAsync(UpdateShipCommand updateShipCommand)
        {
            var result = await _mediator.Send(updateShipCommand);
            return Ok(result);
        }

        /// <summary>
        /// Delete a ship
        /// </summary>
        /// <param name="shipId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{shipId}")]
        [ProducesResponseType(typeof(BaseResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteShipAsync(Guid shipId)
        {
            var result = await _mediator.Send(new DeleteShipCommand(shipId));
            return Ok(result);
        }

        /// <summary>
        /// Get all ship
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        [ProducesResponseType(typeof(List<ShipResponseModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllShipQuery());
            return Ok(result);
        }
    }
}
