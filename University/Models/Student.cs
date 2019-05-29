using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }


        //Navigation properties, ej i databasen
        public Address Address { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }


    }
}
