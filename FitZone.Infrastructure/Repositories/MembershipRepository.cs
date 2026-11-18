
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;
using FitZone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FitZone.Infrastructure.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly FitZoneDbContext _context;

        public MembershipRepository(FitZoneDbContext context)
        {
            _context = context;
        }

        public void AddMembership(Membership membership)
        {
            _context.Memberships.Add(membership);
            _context.SaveChanges();
        }

        public Membership GetActiveMembershipByMemberId(int memberId)
        {
            return _context.Memberships
                .Where(m => m.MemberId == memberId &&
                            m.Status == "Active" &&
                            m.EndDate > DateTime.Now)
                .OrderByDescending(m => m.EndDate)
                .FirstOrDefault();
        }

        public void UpdateMembership(Membership membership)
        {
            _context.Memberships.Update(membership);
            _context.SaveChanges();
        }
    }
}
