using AutoMapper;
using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Interfaces;
using FitZone.Domain.Models.DTOs.MembersDTOs;
using FitZone.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitZone.Application.Services.Implementations
{
    public class MemberService : IMemberService
    {

        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        private readonly IMembershipRepository _membershipRepository;

        public MemberService(
    IMemberRepository memberRepository,
    IMembershipRepository membershipRepository,
    IMapper mapper)
        {
            _memberRepository = memberRepository;
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }






        public int AddMember(CreateMemberDTO memberDto)
        {
            if (memberDto == null)
                throw new Exception("Member cannot be null.");

            if (memberDto.MembershipTypeId != 1 &&
                memberDto.MembershipTypeId != 2)
                throw new Exception("Invalid membership type.");

            var newMember = _mapper.Map<Member>(memberDto);

            newMember.PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(memberDto.Password);

            _memberRepository.AddMember(newMember);

            Membership membership;

            if (memberDto.MembershipTypeId == 1)
            {
                membership = new BasicMembership
                {
                    Type = "Basic",
                    RemainingVisits = 12
                };
            }
            else
            {
                membership = new PremiumMembership
                {
                    Type = "Premium",
                    RemainingVisits = -1
                };
            }

            membership.MemberId = newMember.Id;
            membership.StartDate = DateTime.Now;
            membership.EndDate = DateTime.Now.AddDays(30);
            membership.Status = "Active";

            _membershipRepository.AddMembership(membership);

            return newMember.Id;
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




        public MemberDTO Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required.");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required.");

            var member = _memberRepository.GetMemberByEmail(email.Trim());

            if (member == null)
                throw new Exception("Member with this email does not exist.");

            bool isPasswordCorrect =
                BCrypt.Net.BCrypt.Verify(password, member.PasswordHash);

            if (!isPasswordCorrect)
                throw new Exception("Incorrect password.");

            return _mapper.Map<MemberDTO>(member);
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
