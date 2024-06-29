using DevLibraryMads.Application.Commands.CreateOrder;
using DevLibraryMads.Application.Commands.FinishOrder;
using DevLibraryMads.Application.Commands.UpdateOrder;
using DevLibraryMads.Application.Queries.GetOrderAll;
using DevLibraryMads.Application.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevLibraryMads.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllOrderQuery = new GetOrderAllQuery(query);

            var orders = await _mediator.Send(getAllOrderQuery);

            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetById(int id)
        {

            if (id == null)
                return BadRequest();

            var getOrderByIdQuery = new GetOrderByIdQuery(id);

            var order = await _mediator.Send(getOrderByIdQuery);

            return Ok(order);

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand orderCommand)
        {
            var id = await _mediator.Send(orderCommand);

            return CreatedAtAction(nameof(GetById), new { id = id }, orderCommand);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ReturnedBook(int id)
        {
            var updateOrder = new UpdateOrderCommand(id);

            await _mediator.Send(updateOrder);

            return NoContent();
        }
    }
}
