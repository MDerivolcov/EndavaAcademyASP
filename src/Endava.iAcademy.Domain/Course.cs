using System;
using System.Collections.Generic;

namespace Endava.iAcademy.Domain
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public float Rating { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
