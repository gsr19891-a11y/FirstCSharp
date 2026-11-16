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
        public string Type { get; set; } = string.Empty; // Basic / Premium

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemainingVisits { get; set; }

        [Required]
        public string Status { get; set; } = "Active"; // Active / Expired
    }

    public class BasicMembership : Membership
    {
        // Специфичная логика или свойства для базового абонемента
    }

    public class PremiumMembership : Membership
    {
        // Специфичная логика или свойства для премиум абонемента
    }
}