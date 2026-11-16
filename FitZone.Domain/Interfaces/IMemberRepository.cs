using FitZone.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitZone.Domain.Interfaces
{
    public interface IMemberRepository
    {
        void UpdateMember(Member member);
        void AddMember(Member member);
        void DeleteMember(Member member);
        List<Member> GetAllMembers();
        Member GetMemberById(int Id);

    }
}
