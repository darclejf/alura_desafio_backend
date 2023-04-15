using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Extensions;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class TutorCommandHandler : BasePersonHandler<Tutor>, //TODO refatorar para um PersonHandler??
                        IRequestHandler<CreateTutorCommandRequest, ApplicationResponse<TutorResponse>>,
                        IRequestHandler<ChangeTutorPropertiesCommandRequest, ApplicationResponse<TutorResponse>>,
                        IRequestHandler<ChangeTutorAboutCommandRequest, ApplicationResponse<TutorResponse>>,
                        IRequestHandler<ChangeTutorAddressCommandRequest, ApplicationResponse<TutorResponse>>,
                        IRequestHandler<ChangeTutorNameCommandRequest, ApplicationResponse<TutorResponse>>,
                        IRequestHandler<ChangeTutorPhoneCommandRequest, ApplicationResponse<TutorResponse>>,
                        IRequestHandler<ChangeTutorUrlImageCommandRequest, ApplicationResponse<TutorResponse>>,
                        IRequestHandler<DeleteTutorCommandRequest, ApplicationResponse<bool>> 
    {
        private readonly IMapper _mapper;

        public TutorCommandHandler(ITutorRepository repository, ICityRepository cityRepository, IMapper mapper) : base(repository, cityRepository)
        {
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<TutorResponse>> Handle(CreateTutorCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new CreateTutorCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<TutorResponse>(false, validation.ToErrorResponse());

            var entity = Tutor.Create(command.Request.Name, 
                                    command.Request.Email,
                                    command.UserId,
                                    command.Request.Phone);

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return new ApplicationResponse<TutorResponse>(true, _mapper.Map<TutorResponse>(entity));
        }

        public async Task<ApplicationResponse<bool>> Handle(DeleteTutorCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new DeleteTutorCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<bool>(false, validation.ToErrorResponse());

            var entity = await GetByIdAsync(command.Id);
            await _repository.DeleteAsync(entity);
            return new ApplicationResponse<bool>{ IsValid = true, Result = true };
        }

        public async Task<ApplicationResponse<TutorResponse>> Handle(ChangeTutorPropertiesCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new ChangeTutorPropertiesCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<TutorResponse>(false, validation.ToErrorResponse());

            var entity = await ChangePropertiesAsync(command.Id, command.Request);
            return new ApplicationResponse<TutorResponse>(true, _mapper.Map<TutorResponse>(entity));
        }

        public async Task<ApplicationResponse<TutorResponse>> Handle(ChangeTutorAboutCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(command.Id);
            entity.ChangeAbout(command.Request.About);
            await _repository.SaveAsync();
            return new ApplicationResponse<TutorResponse>(true, _mapper.Map<TutorResponse>(entity));
        }

        public async Task<ApplicationResponse<TutorResponse>> Handle(ChangeTutorAddressCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new ChangeTutorAddressCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<TutorResponse>(false, validation.ToErrorResponse());

            var entity = await ChangeAddressAsync(command.Id, command.Request);
            return new ApplicationResponse<TutorResponse>(true, _mapper.Map<TutorResponse>(entity));
        }

        public async Task<ApplicationResponse<TutorResponse>> Handle(ChangeTutorNameCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new ChangeTutorNameCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<TutorResponse>(false, validation.ToErrorResponse());

            var entity = await ChangeNameAsync(command.Id, command.Request);
            return new ApplicationResponse<TutorResponse>(true, _mapper.Map<TutorResponse>(entity));
        }

        public async Task<ApplicationResponse<TutorResponse>> Handle(ChangeTutorPhoneCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await ChangePhoneAsync(command.Id, command.Request);
            return new ApplicationResponse<TutorResponse>(true, _mapper.Map<TutorResponse>(entity));
        }

        public async Task<ApplicationResponse<TutorResponse>> Handle(ChangeTutorUrlImageCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await ChangeUrlImageAsync(command.Id, command.Request);
            return new ApplicationResponse<TutorResponse>(true, _mapper.Map<TutorResponse>(entity));
        }
    }
}
