using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;
using FitZone.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace FitZone.Infrastructure.Repositories
{
    public class GymHallRepository : IGymHallRepository
    {
        private readonly FitZoneDbContext _context;

        public GymHallRepository(FitZoneDbContext context)
        {
            _context = context;
        }

        public void AddHall(GymHall hall)
        {
            _context.GymHalls.Add(hall);
            _context.SaveChanges();
        }

        public List<GymHall> GetAllHalls()
        {
            return _context.GymHalls.ToList();
        }
    }
}