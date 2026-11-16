using AutoMapper;
using FitZone.Domain.Models.DTOs.MembersDTOs;
using FitZone.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitZone.Application.Profiles
{
    internal class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDTO>();
            CreateMap<MemberDTO, Member>();

            CreateMap<Member, CreateMemberDTO>();
            CreateMap<CreateMemberDTO, Member>();

            CreateMap<Member, UpdateMemberDTO>();
            CreateMap<UpdateMemberDTO, Member>();
        }
    }
}
