using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Resources;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeShelterPropertiesCommandRequest : IRequest<ApplicationResponse<ShelterResponse>>
    {
        public Guid Id { get; set; }
        public UpdatePersonRequest Request { get; set; }

        public ChangeShelterPropertiesCommandRequest(Guid id, UpdatePersonRequest updatePersonRequest)
        {
            Id = id;
            Request = updatePersonRequest;
        }
    }

    public class ChangeShelterPropertiesCommandRequestValidation : AbstractValidator<ChangeShelterPropertiesCommandRequest>
    {
        public ChangeShelterPropertiesCommandRequestValidation()
        {
            RuleFor(e => e.Id)
                .NotEqual(Guid.Empty)
                .WithMessage(Messages.EmptyEntityIdException);

            RuleFor(e => e.Request.Name)
                .NotEmpty()
                .WithMessage(Messages.EmptyNameException);
        }
    }
}
