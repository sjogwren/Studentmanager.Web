using StudentManagement.Model.Student;
using StudentManagement.Model.Subjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Web.Models
{
    public class StudentSubjectVM
    {
        public Student Student { get; set; }
        public Subjects Subject { get; set; }
        public List<Student> Students { get; set; }
        public List<Subjects> Subjects { get; set; }
        public string StudentExistMessage { get; set; }
        public string SubjectExistMessage { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
        public StudentSubject StudentSubject { get; set; }
    }

    public class StudentSubject
    {
        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentIDNumber { get; set; }
        public string StudentAddress { get; set; }
        public string StudentMobile { get; set; }
        public string StudentEmailAddress { get; set; }
        public int StudentAge { get; set; }
        public int StudentNumber { get; set; }
        public int? UserID { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
    }
}
