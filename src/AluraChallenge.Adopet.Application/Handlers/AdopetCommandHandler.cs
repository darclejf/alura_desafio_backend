﻿using AluraChallenge.Adopet.Application.Commands;
using AluraChallenge.Adopet.Application.Response;
using AluraChallenge.Adopet.Core.Exceptions;
using AluraChallenge.Adopet.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace AluraChallenge.Adopet.Application.Handlers
{
    public class AdopetCommandHandler :
                                IRequestHandler<AdopetPetCommandRequest, ApplicationResponse<AdopetResponse>>,
                                IRequestHandler<DeleteAdopetCommandRequest, ApplicationResponse<bool>>

    {
        private readonly ITutorRepository _tutorRepository;
        private readonly IAdopetRepository _adopetRepository;
        private readonly IShelterRepository _shelterRepository;
        private readonly IMapper _mapper;

        public AdopetCommandHandler(ITutorRepository tutorRepository, IAdopetRepository adopetRepository, IShelterRepository shelterRepository, IMapper mapper)
        {
            _tutorRepository = tutorRepository;
            _adopetRepository = adopetRepository;
            _shelterRepository = shelterRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<AdopetResponse>> Handle(AdopetPetCommandRequest request, CancellationToken cancellationToken)
        {
            var pet = await _shelterRepository.GetPetByIdAsync(request.PetId);
            if (pet == null)
                throw new EntityNotFoundException();
            
            var tutor = await _tutorRepository.GetByIdAsync(request.TutorId);
            if (tutor == null)
                throw new EntityNotFoundException();

            var adopet = Domain.Adopet.Create(tutor, pet);
            await _adopetRepository.AddAsync(adopet);
            await _adopetRepository.SaveAsync();
            return new ApplicationResponse<AdopetResponse> { IsValid = true, Result = _mapper.Map<AdopetResponse>(adopet) };
        }

        public async Task<ApplicationResponse<bool>> Handle(DeleteAdopetCommandRequest request, CancellationToken cancellationToken)
        {
            var adopet = await _adopetRepository.GetByIdAsync(request.Id);
            if (adopet == null)
                throw new EntityNotFoundException();

            adopet.Pet.NotAdopeted(); //TODO regra de domínio?
            await _adopetRepository.DeleteAsync(adopet);
            await _adopetRepository.SaveAsync();
            return new ApplicationResponse<bool> { IsValid = true, Result = true };
        }
    }
}
