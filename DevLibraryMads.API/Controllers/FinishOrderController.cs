using DevLibraryMads.Application.Commands.FinishOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLibraryMads.API.Controllers
{
    [Route("api/finishOrders")]
    [ApiController]
    public class FinishOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinishOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> FinishOrder([FromBody] FinishOrderCommand finishOrderCommand)
        {
            await _mediator.Send(finishOrderCommand);

            return NoContent();
        }
    }
}
