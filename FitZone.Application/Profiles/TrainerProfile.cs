using AutoMapper;
using FitZone.Domain.Models.DTOs.TrainersDTOs;
using FitZone.Domain.Models.Entities;

namespace FitZone.Application.Profiles
{
    public class TrainerProfile : Profile
    {
        public TrainerProfile()
        {
            CreateMap<CreateTrainerDTO, Trainer>();
            CreateMap<Trainer, TrainerDTO>();
        }
    }
}