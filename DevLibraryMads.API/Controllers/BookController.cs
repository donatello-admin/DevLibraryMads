using DevLibraryMads.Application.Commands.CreateBook;
using DevLibraryMads.Application.Commands.UpdateBook;
using DevLibraryMads.Application.Queries.GetBookAll;
using DevLibraryMads.Application.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevLibraryMads.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin,client")]
        public async Task<IActionResult> GetAll(string query)
        {
            var getBookAll = new GetBookAllQuery(query);
            var books = await _mediator.Send(getBookAll);

            return Ok(books);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,client")]
        public async Task<IActionResult> GetById(int id)
        {

            if (id == null)
                return BadRequest();

            var getBookByIdQuery = new GetBookByIdQuery(id);
            var book = await _mediator.Send(getBookByIdQuery);

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand bookCommand)
        {

            var id = await _mediator.Send(bookCommand);

            return CreatedAtAction(nameof(GetById), new { id = id }, bookCommand);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update([FromBody] UpdateBookCommand command)
        {
            var updateBook = await _mediator.Send(command);

            if (updateBook == null)
            {
                return BadRequest();
            }


            return Ok(updateBook);
        }
    }
}
