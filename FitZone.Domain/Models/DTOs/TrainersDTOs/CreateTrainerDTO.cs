using System;
using System.Collections.Generic;
using System.Text;

namespace FitZone.Domain.Models.DTOs.TrainersDTOs
{
    public class CreateTrainerDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
