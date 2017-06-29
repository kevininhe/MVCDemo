using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTest.Models
{
    public class University
    {

        public University()
        {
            Students = new List<Student>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UniversityID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}