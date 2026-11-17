
using FitZone.Domain.Models.DTOs.TrainersDTOs;

namespace FitZone.Application.Services.Interfaces
{
    public interface ITrainerService
    {
        void CreateTrainerAsync(CreateTrainerDTO dto);

        List<TrainerDTO> GetAllTrainersAsync();
    }
}
