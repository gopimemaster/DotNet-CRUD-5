using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNet5Crud.Models
{
    public class StudentValidator
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

      
        [Required(ErrorMessage = "You Must Enter a Phone Number")]
        [MaxLength(10)]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a Valid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "You Must Enter a Course name")]
        [Display(Name = "Course")]
        [RegularExpression(@"^[a-zA-Z./]+$", ErrorMessage = "Enter a Valid course name")]
        public string Course { get; set; }

        [Required]
        [Display(Name = "Joining Date")]
        public decimal JoiningDate { get; set; }
    }

    [ModelMetadataType(typeof(StudentValidator))]
    public partial class Student
    {
    }
}

