using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitZone.Domain.Models.DTOs.MembersDTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        
        public int MembershipTypeId { get; set; }

        public override string? ToString()
        {
            return @$"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, MembershipTypeId: {MembershipTypeId}";
        }
    }
}
