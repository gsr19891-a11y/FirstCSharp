using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitZone.Domain.Models.Entities
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        // Связь с расписанием тренировок тренера
        public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();
    }
}