using System;

namespace FitZone.Domain.Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public int SessionId { get; set; }
        public WorkoutSession WorkoutSession { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Active"; // Active / Cancelled
    }
}