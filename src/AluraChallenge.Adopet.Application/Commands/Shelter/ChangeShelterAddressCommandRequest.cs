using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterAddressCommandRequest : IRequest<ApplicationResponse<ShelterResponse>>
    {
        public Guid Id { get; set; }
        public AddressRequest Request { get; set; }

        public ChangeShelterAddressCommandRequest(Guid id, AddressRequest request)
        {
            Id = id;
            Request = request;
        }
    }

    public class ChangeShelterAddressCommandRequestValidation : AbstractValidator<ChangeShelterAddressCommandRequest>
    {
        public ChangeShelterAddressCommandRequestValidation()
        {
            RuleFor(e => e.Id)
                    .NotEqual(Guid.Empty)
                    .WithName(nameof(EmptyEntityIdException));
        }
    }
}
