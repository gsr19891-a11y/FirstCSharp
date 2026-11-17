using FitZone.Domain.Models.Entities;
using System.Collections.Generic;

namespace FitZone.Domain.Interfaces
{
    public interface IWorkoutSessionRepository
    {
        List<WorkoutSession> GetAllActiveSessions();
        WorkoutSession GetSessionById(int id);
        void AddSession(WorkoutSession session);
        void UpdateSession(WorkoutSession session);

    }
}