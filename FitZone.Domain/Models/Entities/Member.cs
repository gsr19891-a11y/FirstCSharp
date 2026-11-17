using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitZone.Domain.Models.Entities
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }
        public int MembershipTypeId { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
