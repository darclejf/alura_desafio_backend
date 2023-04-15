using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace AluraChallenge.Adopet.Application.Commands
{
    public class DeleteShelterCommandRequest : IRequest<ApplicationResponse<bool>>
    {
        public Guid Id { get; set; }
        public DeleteShelterCommandRequest(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteShelterCommandRequestValidation : AbstractValidator<DeleteShelterCommandRequest>
    {
        public DeleteShelterCommandRequestValidation()
        {
            RuleFor(e => e.Id)
                .NotEqual(Guid.Empty)
                .WithName(nameof(EmptyEntityIdException));
        }
    }
}
