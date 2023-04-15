using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorAddressCommandRequest : IRequest<ApplicationResponse<TutorResponse>>
    {
        public Guid Id { get; set; }
        public AddressRequest Request { get; set; }

        public ChangeTutorAddressCommandRequest(Guid id, AddressRequest request)
        {
            Id = id;
            Request = request;
        }
    }

    public class ChangeTutorAddressCommandRequestValidation : AbstractValidator<ChangeTutorAddressCommandRequest>
    {
        public ChangeTutorAddressCommandRequestValidation()
        {
            RuleFor(e => e.Id)
                    .NotEqual(Guid.Empty)
                    .WithName(nameof(EmptyEntityIdException));
        }
    }
}
