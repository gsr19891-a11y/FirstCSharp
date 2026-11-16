using FitZone.Domain.Models.DTOs.MembersDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitZone.Application.Services.Interfaces
{
    public interface IMemberService
    {
        List<MemberDTO> GetAllMembers();
        MemberDTO GetMemberById(int Id);


        void AddMember(CreateMemberDTO member);
        void UpdateMember(UpdateMemberDTO member);
        void DeleteMember(int Id);
    }
}
