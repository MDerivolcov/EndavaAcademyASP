using Endava.iAcademy.Domain;
using System.Collections.Generic;

namespace Endava.iAcademy.Repository
{
    internal class SampleContext
    {
        public IEnumerable<Course> Courses { get; internal set; }
    }
}