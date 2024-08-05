using System;
using System.Collections.Generic;

namespace DotNet5Crud.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Course { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
