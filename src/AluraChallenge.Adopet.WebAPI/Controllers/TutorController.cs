using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Responses;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.ApplicationQuery.ViewModels;
using AluraChallenge.Adopet.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge.Adopet.WebAPI.Controllers
{
    [ApiController]
    [Route("tutores")]
    public class TutorController : ControllerBase
    {
        private readonly ILogger<TutorController> _logger;
        private readonly IMediator _mediator;
        private readonly TutorQueryServices _tutorQuery;

        public TutorController(ILogger<TutorController> logger, IMediator mediator, TutorQueryServices tutorQuery)
        {
            _logger = logger;
            _mediator = mediator;
            _tutorQuery = tutorQuery;
        }

        /// <summary>
        /// Post simulation validate.
        /// </summary>
        /// <param name="request">The request<see cref="Post"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(CreateTutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateTutorCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromQuery] DeleteTutorCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PaginationListViewModel<TutorListItemViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int? page, int? total)
        {
            return Ok(await _tutorQuery.GetAsync(page, total));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _tutorQuery.GetAsync(id));
        }

        [HttpPatch]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch([FromBody] ChangeProfilePropertiesCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}