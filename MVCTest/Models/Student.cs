using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Models
{
    public class Student
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Remote("CheckSons","Students")]
        [Required]
        public int Sons { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [GradeAttribute]
        public float Grade { get; set; }

        public int UnvId { get; set; }

        [ForeignKey("UnvId")]
        public virtual University Universi { get; set; }

        [NotMapped]
        public List<University> ListOfUniversities { get; set;}
    }

    public class GradeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                float grade = (float)Convert.ToDouble(value);
                if (grade > 5.0 || grade < 0)
                {
                    return new ValidationResult("Grade must be between 0 and 5");
                }
            }
            return ValidationResult.Success;
        }
    }
}