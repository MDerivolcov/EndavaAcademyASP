using System.Collections.Generic;
using Endava.iAcademy.Domain;

namespace Endava.iAcademy.Web.Models
{
    public class CoursesViewModel
    {
        public List<Course> Courses { get; set; }

        public List<string> SortAction { get; set; }

        public string SortParam { get; set; }

        public List<string> CategoryAction { get; set; }

        public string Category { get; set; }

        public CoursesViewModel()
        {
            SortAction = new System.Collections.Generic.List<string>
            { "","Title","Data","Rating" };

            CategoryAction = new System.Collections.Generic.List<string>
            { "","Free","Paid" };
        }
    }
}
