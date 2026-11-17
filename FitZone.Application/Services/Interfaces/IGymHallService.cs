using FitZone.Domain.Models.Entities;
using System.Collections.Generic;

namespace FitZone.Application.Services.Interfaces
{
    public interface IGymHallService
    {
        void CreateHall(string name, int capacity, string location);
        List<GymHall> GetAllHalls();
    }
}