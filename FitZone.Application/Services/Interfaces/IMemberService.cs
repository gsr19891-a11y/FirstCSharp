
using FitZone.Domain.Models.DTOs.MembersDTOs;

namespace FitZone.Application.Services.Interfaces
{
    public interface IMemberService
    {
        List<MemberDTO> GetAllMembers();

        MemberDTO GetMemberById(int Id);

        int AddMember(CreateMemberDTO member);

        void UpdateMember(UpdateMemberDTO member);

        void DeleteMember(int Id);

        MemberDTO Login(string email, string password);
    }
}
