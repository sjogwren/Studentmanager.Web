using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagement.Model.Student
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string StudentFirstName { get; set; }
        [Required]
        public string StudentLastName { get; set; }
        [Required]
        [MaxLength(13)]
        public string StudentIDNumber { get; set; }
        [Required]
        public string StudentAddress { get; set; }
        [Required]
        public string StudentMobile { get; set; }
        [Required]
        [EmailAddress]
        public string StudentEmailAddress { get; set; }
        public int StudentAge { get; set; }
        public int StudentNumber { get; set; }
        public int? UserID { get; set; }
    }
}
