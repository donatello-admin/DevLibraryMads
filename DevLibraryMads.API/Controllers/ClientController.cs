using DevLibraryMads.Application.Commands.CreateClient;
using DevLibraryMads.Application.Commands.UpdateClient;
using DevLibraryMads.Application.Queries.GetClientAll;
using DevLibraryMads.Application.Queries.GetClientById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "admin,client")]
        public async Task<IActionResult> GetAll(string query)
        {

            var clientGetAllQuery = new GetClientAllQuery(query);
            var clients = await _mediator.Send(clientGetAllQuery);

            return Ok(clients);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,client")]
        public async Task<IActionResult> GetById(int id)
        {

            if (id == null)
                return NotFound();

            var getClientByIdQuery = new GetClientByIdQuery(id);

            var client = await _mediator.Send(getClientByIdQuery);


            return Ok(client);
        }

        [HttpPost]
        [Authorize(Roles = "admin,client")]
        public async Task<IActionResult> Create([FromBody] CreateClientCommand client)
        {
            var id = await _mediator.Send(client);

            return CreatedAtAction(nameof(GetById), new { id = id }, client);
        }
        [HttpPut]
        [Authorize(Roles = "admin,client")]
        public async Task<IActionResult> Update([FromBody] UpdateClientCommand command)
        {
            var updateClient = await _mediator.Send(command);

            if (updateClient == null)
            {
                return BadRequest();
            }


            return Ok(updateClient);
        }
    }
}
