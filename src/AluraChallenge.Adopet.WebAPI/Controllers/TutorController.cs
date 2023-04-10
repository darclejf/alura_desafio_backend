using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge.Adopet.WebAPI.Controllers
{
    [ApiController]
    [Route("api/tutores")]
    public class TutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly TutorQueryServices _queryService;

        public TutorController(IMediator mediator, TutorQueryServices queryService)
        {
            _mediator = mediator;
            _queryService = queryService;
        }

        /// <summary>
        /// Post simulation validate.
        /// </summary>
        /// <param name="request">The request<see cref="Post"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreatePersonRequest request)
        {
            return Ok(await _mediator.Send(new CreateTutorCommandRequest(request)));
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteTutorCommandRequest(id)));
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PaginationListResponse<PersonListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int? page, int? total)
        {
            return Ok(await _queryService.GetAsync(page, total));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _queryService.GetAsync(id));
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePersonRequest request)
        {
            return Ok(await _mediator.Send(new ChangeTutorPropertiesCommandRequest(id, request)));
        }

        [HttpPatch("{id}/sobre")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchAbout(Guid id, [FromBody] AboutRequest request)
        {
            return Ok(await _mediator.Send(new ChangeTutorAboutCommandRequest(id, request)));
        }

        [HttpPatch("{id}/endereco")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchAddress(Guid id, [FromBody] AddressRequest request)
        {
            return Ok(await _mediator.Send(new ChangeTutorAddressCommandRequest(id, request)));
        }

        [HttpPatch("{id}/nome")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchName(Guid id, [FromBody] NameRequest request)
        {
            return Ok(await _mediator.Send(new ChangeTutorNameCommandRequest(id, request)));
        }

        [HttpPatch("{id}/telefone")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchPhone(Guid id, [FromBody] PhoneRequest request)
        {
            return Ok(await _mediator.Send(new ChangeTutorPhoneCommandRequest(id, request)));
        }

        [HttpPatch("{id}/imagem")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchUrlImage(Guid id, [FromBody] UrlImageRequest request)
        { 
            return Ok(await _mediator.Send(new ChangeTutorUrlImageCommandRequest(id, request)));
        }
    }
}