using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
