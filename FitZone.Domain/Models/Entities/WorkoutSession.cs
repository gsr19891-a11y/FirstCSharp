using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitZone.Domain.Models.Entities
{
    public class WorkoutSession
    {
        public int Id { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;

        [Required]
        public string Type { get; set; } = string.Empty; // Например, Yoga, Crossfit

        public DateTime StartDateTime { get; set; }
        public int DurationMinutes { get; set; }
        public int Capacity { get; set; }

        [Required]
        public string Status { get; set; } = "Active"; // Active / Cancelled

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public int GymHallId { get; set; }
        public GymHall GymHall { get; set; } = null!;
    }
}