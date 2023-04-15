using AluraChallenge.Adopet.Application.Request;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Resources;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class ChangeTutorNameCommandRequest : IRequest<ApplicationResponse<TutorResponse>>
    {
        public Guid Id { get; set; }
        public NameRequest Request { get; set; }
        public ChangeTutorNameCommandRequest(Guid id, NameRequest request)
        {
            Id = id;
            Request = request;
        }
    }

    public class ChangeTutorNameCommandRequestValidation : AbstractValidator<ChangeTutorNameCommandRequest>
    {
        public ChangeTutorNameCommandRequestValidation()
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
