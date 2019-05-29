using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.ViewModels
{
    public class StudentDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
