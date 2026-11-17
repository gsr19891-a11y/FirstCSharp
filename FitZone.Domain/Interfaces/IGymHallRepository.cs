using FitZone.Domain.Models.Entities;
using System.Collections.Generic;

namespace FitZone.Domain.Interfaces
{
    public interface IGymHallRepository
    {
        void AddHall(GymHall hall);
        List<GymHall> GetAllHalls();
    }
}