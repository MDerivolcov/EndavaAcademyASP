namespace Endava.iAcademy.Domain
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public int CourseId { get; set; }
    }
}
