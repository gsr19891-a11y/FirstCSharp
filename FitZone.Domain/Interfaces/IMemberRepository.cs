using FitZone.Domain.Models.Entities;

namespace FitZone.Domain.Interfaces
{
    public interface IMemberRepository
    {
        void UpdateMember(Member member);
        void AddMember(Member member);
        void DeleteMember(Member member);

        List<Member> GetAllMembers();
        Member GetMemberById(int Id);
        Member GetMemberByEmail(string email);
    }
}