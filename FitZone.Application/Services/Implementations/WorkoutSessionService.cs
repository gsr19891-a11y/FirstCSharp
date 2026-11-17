
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;

namespace FitZone.Application.Services.Implementations
{
    public class WorkoutSessionService : IWorkoutSessionService
    {
        private readonly IWorkoutSessionRepository _sessionRepository;

        public WorkoutSessionService(
            IWorkoutSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public void CreateSession(
            string type,
            DateTime startDateTime,
            int durationMinutes,
            int capacity,
            int trainerId,
            int hallId)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Session type is required.");

            if (durationMinutes <= 0)
                throw new ArgumentException("Duration must be greater than zero.");

            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            if (trainerId <= 0)
                throw new ArgumentException("Invalid trainer ID.");

            if (hallId <= 0)
                throw new ArgumentException("Invalid hall ID.");

            var session = new WorkoutSession
            {
                Type = type,
                StartDateTime = startDateTime,
                DurationMinutes = durationMinutes,
                Capacity = capacity,
                TrainerId = trainerId,
                GymHallId = hallId,
                Status = "Active"
            };

            _sessionRepository.AddSession(session);
        }

        public List<WorkoutSession> GetAllSessions()
        {
            return _sessionRepository.GetAllActiveSessions();
        }

        public List<WorkoutSession> GetAllActiveSessions()
        {
            return _sessionRepository.GetAllActiveSessions();
        }
    }
}
