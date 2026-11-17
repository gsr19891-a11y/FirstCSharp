
using FitZone.Domain.Models.Entities;

namespace FitZone.Application.Services.Interfaces
{
    public interface IWorkoutSessionService
    {
        void CreateSession(
            string type,
            DateTime startDateTime,
            int durationMinutes,
            int capacity,
            int trainerId,
            int hallId);

        List<WorkoutSession> GetAllSessions();

        List<WorkoutSession> GetAllActiveSessions();
    }
}
