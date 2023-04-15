using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Resources;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteTutorCommandRequest : IRequest<ApplicationResponse<bool>>
    {
        public Guid Id { get; set; }

        public DeleteTutorCommandRequest(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteTutorCommandRequestValidation : AbstractValidator<DeleteTutorCommandRequest>
    {
        public DeleteTutorCommandRequestValidation()
        {
            RuleFor(e => e.Id)
                .NotEqual(Guid.Empty)
                .WithMessage(Messages.EmptyEntityIdException);
        }
    }
}
