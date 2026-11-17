
using AutoMapper;
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.DTOs.TrainersDTOs;
using FitZone.Domain.Models.Entities;

namespace FitZone.Application.Services.Implementations
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public TrainerService(
            ITrainerRepository trainerRepository,
            IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public void CreateTrainerAsync(CreateTrainerDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new ArgumentException("FullName and Email are required.");
            }

            var trainer = _mapper.Map<Trainer>(dto);

            _trainerRepository.Add(trainer);
        }

        public List<TrainerDTO> GetAllTrainersAsync()
        {
            var trainers = _trainerRepository.GetAll();

            return _mapper.Map<List<TrainerDTO>>(trainers);
        }
    }
}
