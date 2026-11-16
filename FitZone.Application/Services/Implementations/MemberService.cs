using AutoMapper;
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.DTOs.MembersDTOs;
using FitZone.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitZone.Application.Services.Implementations
{
    public class MemberService : IMemberService
    {

        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }





       public void AddMember(CreateMemberDTO member)
        {
         
            //_memberRepository.AddMember(member);

            //manual mapping---------------------------
            //var newMember = new Member();

            //newMember.FirstName = member.FirstName;
            //newMember.LastName = member.LastName;
            //newMember.MembershipTypeId = member.MembershipTypeId;


            //AutoMapper-------------------------------

            var newMember = _mapper.Map<Member>(member);


            _memberRepository.AddMember(newMember);




        }


        public void DeleteMember(int Id)
        {

            if(Id == 0)
            {
                throw new Exception("Id cannot be zero");
            }

            Member memb = _memberRepository.GetMemberById(Id);

            if(memb == null)
            {
                throw new Exception("Member not found");
            }


            _memberRepository.DeleteMember(memb);
        }




        public List<MemberDTO> GetAllMembers()
        {
            var members = _memberRepository.GetAllMembers();

            if(members == null)
            {
                throw new Exception("No members found");
            }


            var membersDTO = _mapper.Map<List<MemberDTO>>(members);
            return membersDTO;
        }


        public MemberDTO GetMemberById(int Id)
        {
            if(Id == 0)
            {
                throw new Exception("Id cannot be zero");
            }

            Member memb = _memberRepository.GetMemberById(Id);

            if(memb == null)
            {
                throw new Exception("Member not found");
            }

            var memberDTO = _mapper.Map<MemberDTO>(memb);
            return memberDTO;
        }



        public void UpdateMember(UpdateMemberDTO member)
        {
            if(member == null)
            {
                throw new Exception("Member cannot be null");
            }
            if(member.Id == 0)
            {
                throw new Exception("Id cannot be zero");
            }

            var updatedMember = _mapper.Map<Member>(member);
            _memberRepository.UpdateMember(updatedMember);

        }
    }
}
