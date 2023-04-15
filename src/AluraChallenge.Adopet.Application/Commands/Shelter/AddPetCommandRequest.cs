using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class AddPetCommandRequest : IRequest<ApplicationResponse<PetResponse>>
    {
        public AddPetRequest Request { get; set; }

        public AddPetCommandRequest(AddPetRequest request)
        {
            Request = request;
        }
    }

    public class AddPetCommandRequestValidation : AbstractValidator<AddPetCommandRequest>
    {
        public AddPetCommandRequestValidation()
        {
            RuleFor(e => e.Request.ShelterId)
                .NotEqual(Guid.Empty)
                .WithName(nameof(EmptyShelterIdException));

            RuleFor(e => e.Request.Age)
                .NotEmpty()
                .WithName(nameof(EmptyPetAgeException));

            RuleFor(e => e.Request.Behavior)
                .NotEmpty()
                .WithName(nameof(EmptyBehaviorException));

            RuleFor(e => e.Request.Gender)
                .NotEmpty()
                .WithName(nameof(EmptyGenderException));

            RuleFor(e => e.Request.Name)
                .NotEmpty()
                .WithName(nameof(EmptyNameException));

            RuleFor(e => e.Request.Specimen)
                .NotEmpty()
                .WithName(nameof(EmptySpecimenException));

            RuleFor(e => e.Request.Size)
                .NotEmpty()
                .WithName(nameof(EmptySizeException));
        }
    }
}
