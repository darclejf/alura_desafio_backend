using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterNameCommandRequest : IRequest<ApplicationResponse<ShelterResponse>>
    {
        public Guid Id { get; set; }
        public NameRequest Request { get; set; }

        public ChangeShelterNameCommandRequest(Guid id, NameRequest request)
        {
            Id = id;
            Request = request;
        }
    }

    public class ChangeShelterNameCommandRequestValidation : AbstractValidator<ChangeShelterNameCommandRequest>
    {
        public ChangeShelterNameCommandRequestValidation()
        {
            RuleFor(e => e.Id)
                .NotEqual(Guid.Empty)
                .WithName(nameof(EmptyEntityIdException));

            RuleFor(e => e.Request.Name)
                .NotEmpty()
                .WithName(nameof(EmptyNameException));
        }
    }
}
