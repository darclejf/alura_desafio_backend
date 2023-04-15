using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.ApplicationQuery;
using AluraChallenge.Adopet.ApplicationQuery.Response;
using AluraChallenge.Adopet.Authentication.Interfaces;
using AluraChallenge.Adopet.Core.Models;
using AluraChallenge.Adopet.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenge.Adopet.WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = ProfileRole.Shelter)]
    [Route("api/abrigos")]
    public class ShelterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserServices _userService;
        private readonly ShelterQueryServices _queryServices;

        public ShelterController(IMediator mediator, ShelterQueryServices queryServices, IUserServices userService)
        {
            _mediator = mediator;
            _queryServices = queryServices;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreatePersonRequest request)
        {
            var user = await _userService.CreateUserAsync(new Authentication.Models.CreateUserDto
                                                        {
                                                            Email = request.Email,
                                                            Password = request.Password,
                                                            RePassword = request.RePassword,
                                                            Role = ProfileRole.Shelter,
                                                        });

            var response = await _mediator.Send(new CreateTutorCommandRequest(user.Id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new DeleteShelterCommandRequest(id));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
        }

        [HttpGet]
        [AllowAnonymous]
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

        [HttpGet("{id}")]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _queryServices.GetAsync(id));
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ShelterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePersonRequest request)
        {
            var response = await _mediator.Send(new ChangeShelterPropertiesCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeShelterAddressCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeShelterNameCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeShelterPhoneCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeShelterUrlImageCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
        }

        [HttpPost("pet")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostPet([FromBody] AddPetRequest request)
        {
            var response = await _mediator.Send(new AddPetCommandRequest(request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
        }
    }
}
