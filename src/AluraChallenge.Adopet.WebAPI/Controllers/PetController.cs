using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.ApplicationQuery.Response;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge.Adopet.WebAPI.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly PetQueryServices _queryServices;

        public PetController(IMediator mediator, PetQueryServices queryServices)
        {
            _mediator = mediator;
            _queryServices = queryServices;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes="Bearer", Roles=ProfileRole.Shelter)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] AddPetRequest request)
        {
            return Ok(await _mediator.Send(new AddPetCommandRequest(request)));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes="Bearer", Roles=ProfileRole.Shelter)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteShelterCommandRequest(id)));
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PaginationListResponse<PetListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int? page, int? total)
        {
            return Ok(await _queryServices.GetAsync(page, total));
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await _queryServices.GetAsync(id));
        }

        //[HttpPut("{id}")]
        //[Produces("application/json")]
        //[Consumes("application/json")]
        //[ProducesResponseType(typeof(ChangePersonPropertiesResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdatePersonRequest request)
        //{
        //    return Ok(await _mediator.Send(new ChangeShelterPropertiesCommandRequest(id, request)));
        //}
    }
}
