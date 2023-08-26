using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentManagement.Model.Subjects
{
    [Table("Subjects")]
    public class Subjects
    {
        [Key]
        public int SubjectID { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string SubjectDescription { get; set; }
        [Required]
        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        public int? UserID { get; set; }
    }
}
