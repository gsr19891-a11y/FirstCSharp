using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;
using FitZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FitZone.Infrastructure.Repositories
{
    public class WorkoutSessionRepository : IWorkoutSessionRepository
    {
        private readonly FitZoneDbContext _context;

        public WorkoutSessionRepository(FitZoneDbContext context)
        {
            _context = context;
        }

        public List<WorkoutSession> GetAllActiveSessions()
        {
            return _context.WorkoutSessions
                .Include(s => s.Trainer)
                .Include(s => s.Bookings)
                .Where(s => s.Status == "Active")
                .ToList();
        }

        public WorkoutSession GetSessionById(int id)
        {
            return _context.WorkoutSessions
                .Include(s => s.Trainer)
                .Include(s => s.Bookings)
                .FirstOrDefault(s => s.Id == id);
        }

        public void AddSession(WorkoutSession session)
        {
            _context.WorkoutSessions.Add(session);
            _context.SaveChanges();
        }

        public void UpdateSession(WorkoutSession session)
        {
            _context.WorkoutSessions.Update(session);
            _context.SaveChanges();
        }
    }
}