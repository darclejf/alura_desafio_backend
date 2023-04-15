using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Resources;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class CreateTutorCommandRequest : IRequest<ApplicationResponse<TutorResponse>>
    {
        public Guid UserId { get; set; }
        public CreatePersonRequest Request { get; set; }

        public CreateTutorCommandRequest(Guid userId, CreatePersonRequest request)
        {
            UserId = userId;
            Request = request;
        }
    }

    public class CreateTutorCommandRequestValidation : AbstractValidator<CreateTutorCommandRequest>
    {
        public CreateTutorCommandRequestValidation()
        {
            RuleFor(e => e.Request.Email)
                .NotEmpty()
                .WithMessage(Messages.InvalidEmailException);

            RuleFor(e => e.Request.Name)
                .NotEmpty()
                .WithMessage(Messages.EmptyNameException);

            RuleFor(e => e.Request.Password)
                .NotEmpty()
                .WithMessage(Messages.InvalidPasswordException);

            RuleFor(e => e.Request.RePassword)
                .NotEmpty()
                .WithMessage(Messages.InvalidConfirmationPasswordException);
        }
    }
}
