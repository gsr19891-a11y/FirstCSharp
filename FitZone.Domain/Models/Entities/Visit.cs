using System;

namespace FitZone.Domain.Models.Entities
{
    public class Visit
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;

        public DateTime VisitTime { get; set; } = DateTime.Now;
    }
}