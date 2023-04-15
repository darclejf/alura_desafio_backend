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
    [Authorize(AuthenticationSchemes="Bearer", Roles=ProfileRole.Tutor)]
    [Route("api/tutores")]
    public class TutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserServices _userService;
        private readonly TutorQueryServices _queryService;

        public TutorController(IMediator mediator, TutorQueryServices queryService, IUserServices userService)
        {
            _mediator = mediator;
            _queryService = queryService;
            _userService = userService;
        }

        /// <summary>
        /// Post simulation validate.
        /// </summary>
        /// <param name="request">The request<see cref="Post"/>.</param>
        /// <returns>The <see cref="Task{ActionResult}"/>.</returns>
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TutorResponse), StatusCodes.Status200OK)]
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
                                                            Role = ProfileRole.Tutor,
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
            var response = await _mediator.Send(new DeleteTutorCommandRequest(id));
            if (response.IsValid)
            {
                await _userService.DeleteUserAsync(id);
                return Ok(response.Result);
            }
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
            return Ok(await _queryService.GetAsync(page, total));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
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
            var response = await _mediator.Send(new ChangeTutorPropertiesCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeTutorAboutCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeTutorAddressCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeTutorNameCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeTutorPhoneCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
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
            var response = await _mediator.Send(new ChangeTutorUrlImageCommandRequest(id, request));
            if (response.IsValid)
                return Ok(response.Result);
            return BadRequest(new ErrorResponse(response.Messages));
        }
    }
}