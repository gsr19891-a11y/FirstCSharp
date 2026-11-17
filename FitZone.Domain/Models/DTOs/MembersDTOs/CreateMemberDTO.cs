using System.ComponentModel.DataAnnotations;

namespace FitZone.Domain.Models.DTOs.MembersDTOs
{
    public class CreateMemberDTO
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } 

        public int MembershipTypeId { get; set; }
    }
}