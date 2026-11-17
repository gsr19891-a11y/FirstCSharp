
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.Entities;
using FitZone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitZone.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly FitZoneDbContext _context;

        public MemberRepository(FitZoneDbContext context)
        {
            _context = context;
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }

        public List<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member GetMemberById(int Id)
        {
            return _context.Members.Find(Id);
        }

        public void UpdateMember(Member member)
        {
            var memberOld = _context.Members.Find(member.Id);

            if (memberOld == null)
            {
                throw new Exception("Member not found for update");
            }

            memberOld.FirstName = member.FirstName;
            memberOld.LastName = member.LastName;
            memberOld.MembershipTypeId = member.MembershipTypeId;

            _context.SaveChanges();
        }
    }
}
