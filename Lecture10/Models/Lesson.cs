using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10.Models
{
    internal class Lesson
    {
        public Lesson(string name, string duration, int hours)
        {
            Name = name;
            Duration = duration;
            Hours = hours;
        }

        public string Name { get; set; }
        public string Duration { get; set; }
        public int Hours { get; set; }
    }
}
