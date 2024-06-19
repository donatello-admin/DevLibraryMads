using DevLibraryMads.Application.Commands.CreateClient;
using DevLibraryMads.Application.Queries.GetClientAll;
using DevLibraryMads.Application.Queries.GetClientById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevLibraryMads.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {

            var clientGetAllQuery = new GetClientAllQuery(query);
            var clients = await _mediator.Send(clientGetAllQuery);

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            if (id == null)
                return NotFound();

            var getClientByIdQuery = new GetClientByIdQuery(id);

            var client = await _mediator.Send(getClientByIdQuery);


            return Ok(client);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateClientCommand client)
        {
            var id = await _mediator.Send(client);

            return CreatedAtAction(nameof(GetById), new { id = id }, client);
        }
    }
}
