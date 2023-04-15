using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Extensions;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Domain;
using AluraChallenge.Adopet.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class ShelterCommandHandler : BasePersonHandler<Shelter>,
                                IRequestHandler<CreateShelterCommandRequest, ApplicationResponse<ShelterResponse>>,
                                IRequestHandler<ChangeShelterPropertiesCommandRequest, ApplicationResponse<ShelterResponse>>,
                                IRequestHandler<ChangeShelterAddressCommandRequest, ApplicationResponse<ShelterResponse>>,
                                IRequestHandler<ChangeShelterNameCommandRequest, ApplicationResponse<ShelterResponse>>,
                                IRequestHandler<ChangeShelterPhoneCommandRequest, ApplicationResponse<ShelterResponse>>,
                                IRequestHandler<ChangeShelterUrlImageCommandRequest, ApplicationResponse<ShelterResponse>>,
                                IRequestHandler<DeleteShelterCommandRequest, ApplicationResponse<bool>>,
                                IRequestHandler<AddPetCommandRequest, ApplicationResponse<PetResponse>>
    {
        private readonly IMapper _mapper;

        public ShelterCommandHandler(IShelterRepository repository, ICityRepository cityRepository, IMapper mapper) : base(repository, cityRepository)
        {
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<ShelterResponse>> Handle(CreateShelterCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new CreateShelterCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<ShelterResponse>(false, validation.ToErrorResponse());

            var entity = Shelter.Create(command.Request.Name,
                                   command.Request.Email,
                                   command.UserId,
                                   command.Request.Phone);

            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return new ApplicationResponse<ShelterResponse>(true, _mapper.Map<ShelterResponse>(entity));
        }

        public async Task<ApplicationResponse<PetResponse>> Handle(AddPetCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new AddPetCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<PetResponse>(false, validation.ToErrorResponse());

            var entity = await GetByIdAsync(command.Request.ShelterId);
            var pet = entity.AddPet(
                            name: command.Request.Name,
                            specimen: command.Request.Specimen,
                            size: command.Request.Size,
                            behavior: command.Request.Behavior, 
                            gender: command.Request.Gender, 
                            age: command.Request.Age);
            await _repository.SaveAsync();
            return new ApplicationResponse<PetResponse>(true, _mapper.Map<PetResponse>(entity));
        }

        public async Task<ApplicationResponse<ShelterResponse>> Handle(ChangeShelterPropertiesCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new ChangeShelterPropertiesCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<ShelterResponse>(false, validation.ToErrorResponse());

            var entity = await ChangePropertiesAsync(command.Id, command.Request);
            return new ApplicationResponse<ShelterResponse>(true, _mapper.Map<ShelterResponse>(entity));
        }

        public async Task<ApplicationResponse<ShelterResponse>> Handle(ChangeShelterAddressCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new ChangeShelterAddressCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<ShelterResponse>(false, validation.ToErrorResponse());

            var entity = await ChangeAddressAsync(command.Id, command.Request);
            return new ApplicationResponse<ShelterResponse>(true, _mapper.Map<ShelterResponse>(entity));
        }

        public async Task<ApplicationResponse<ShelterResponse>> Handle(ChangeShelterNameCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new ChangeShelterNameCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<ShelterResponse>(false, validation.ToErrorResponse());

            var entity = await ChangeNameAsync(command.Id, command.Request);
            return new ApplicationResponse<ShelterResponse>(true, _mapper.Map<ShelterResponse>(entity));
        }

        public async Task<ApplicationResponse<ShelterResponse>> Handle(ChangeShelterPhoneCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await ChangePhoneAsync(command.Id, command.Request);
            return new ApplicationResponse<ShelterResponse>(true, _mapper.Map<ShelterResponse>(entity));
        }

        public async Task<ApplicationResponse<ShelterResponse>> Handle(ChangeShelterUrlImageCommandRequest command, CancellationToken cancellationToken)
        {
            var entity = await ChangeUrlImageAsync(command.Id, command.Request);
            return new ApplicationResponse<ShelterResponse>(true, _mapper.Map<ShelterResponse>(entity));
        }
 
        public async Task<ApplicationResponse<bool>> Handle(DeleteShelterCommandRequest command, CancellationToken cancellationToken)
        {
            var validation = new DeleteShelterCommandRequestValidation().Validate(command);
            if (!validation.IsValid)
                return new ApplicationResponse<bool>(false, validation.ToErrorResponse());
            return new ApplicationResponse<bool> { IsValid = true, Result = await DeleteAsync(command.Id) };
        }
    }
}
