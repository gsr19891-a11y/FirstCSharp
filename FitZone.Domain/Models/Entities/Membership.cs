
using System;
using System.ComponentModel.DataAnnotations;

namespace FitZone.Domain.Models.Entities
{
    public abstract class Membership
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        [Required]
        public string Type { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // -1 means unlimited
        public int RemainingVisits { get; set; }

        [Required]
        public string Status { get; set; } = "Active";
    }

    public class BasicMembership : Membership
    {
    }

    public class PremiumMembership : Membership
    {
    }
}
