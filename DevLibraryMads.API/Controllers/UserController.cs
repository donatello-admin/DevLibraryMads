using DevLibraryMads.Application.Commands.CreateUser;
using DevLibraryMads.Application.Commands.LoginUser;
using DevLibraryMads.Application.Queries.GetUserAll;
using DevLibraryMads.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevLibraryMads.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin,client")]
        public async Task<IActionResult> GetAll(string query)
        {

            var userGetAllQuery = new GetUserAllQuery(query);
            var users = await _mediator.Send(userGetAllQuery);

            return Ok(users);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == null)
                return BadRequest();

            var getUserByIdQuery = new GetUserByIdQuery(id);

            var user = await _mediator.Send(getUserByIdQuery);

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = 1 }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserCommand = await _mediator.Send(command);

            if (loginUserCommand == null)
            {
                return BadRequest();
            }


            return Ok(loginUserCommand);
        }
    }
}
