
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;
using FitZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitZone.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly FitZoneDbContext _context;

        public TrainerRepository(FitZoneDbContext context)
        {
            _context = context;
        }

        public void Add(Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
        }

        public List<Trainer> GetAll()
        {
            return _context.Trainers
                .AsNoTracking()
                .ToList();
        }

        public Trainer? GetById(int id)
        {
            return _context.Trainers.Find(id);
        }
    }
}
