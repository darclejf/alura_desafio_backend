using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge.Adopet.WebAPI.Controllers
{
    [ApiController]
    [Route("api/abrigos")]
    public class ShelterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ShelterQueryServices _queryServices;

        public ShelterController(IMediator mediator, ShelterQueryServices queryServices)
        {
            _mediator = mediator;
            _queryServices = queryServices;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreatePersonRequest request)
        {
            return Ok(await _mediator.Send(new CreateShelterCommandRequest(request)));
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
            return Ok(await _mediator.Send(new DeleteShelterCommandRequest(id)));
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
            return Ok(await _queryServices.GetAsync(page, total));
        }

        //[HttpGet("{id}")]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(TutorViewModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    return Ok(await _tutorQuery.GetAsync(id));
        //}

        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePersonRequest request)
        {
            return Ok(await _mediator.Send(new ChangeShelterPropertiesCommandRequest(id, request)));
        }

        [HttpPatch("{id}/endereco")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchAddress(Guid id, [FromBody] AddressRequest request)
        {
            return Ok(await _mediator.Send(new ChangeShelterAddressCommandRequest(id, request)));
        }

        [HttpPatch("{id}/nome")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchName(Guid id, [FromBody] NameRequest request)
        {
            return Ok(await _mediator.Send(new ChangeShelterNameCommandRequest(id, request)));
        }

        [HttpPatch("{id}/telefone")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchPhone(Guid id, [FromBody] PhoneRequest request)
        {
            return Ok(await _mediator.Send(new ChangeShelterPhoneCommandRequest(id, request)));
        }

        [HttpPatch("{id}/imagem")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchUrlImage(Guid id, [FromBody] UrlImageRequest request)
        {
            return Ok(await _mediator.Send(new ChangeShelterUrlImageCommandRequest(id, request)));
        }

        [HttpPost("pet")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostPet([FromBody] AddPetCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
