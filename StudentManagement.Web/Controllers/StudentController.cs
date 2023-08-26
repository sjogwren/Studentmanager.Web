using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Model.Student;
using StudentManagement.Model.Subjects;
using StudentManagement.Web.Api_Router;
using StudentManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Web.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        [HttpGet]
        [Authorize]
        public IActionResult Newstudent()
        {
            var StudentSubjectVM = new StudentSubjectVM();
            StudentSubjectVM.StudentExistMessage = null;
            StudentSubjectVM.SubjectExistMessage = null;


            return View(StudentSubjectVM);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Newstudent(StudentSubjectVM s)
        {
            var student = new Student(); var subject = new Subjects();

            student.StudentFirstName = s.Student.StudentFirstName;
            student.StudentLastName = s.Student.StudentLastName;
            student.StudentIDNumber = s.Student.StudentIDNumber;
            student.StudentAddress = s.Student.StudentAddress;
            student.StudentMobile = s.Student.StudentMobile;
            student.StudentEmailAddress = s.Student.StudentEmailAddress;
            student.StudentAge = 0;
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);
            student.StudentNumber = randomNumber;
            student.UserID = User.GetUserId();

            //API CALL TO INSERT STUDENT
            await StudentService.InsertStudent(student);

            //GET NEW STUDENT ID AND MAP TO SUBJECT
            var currentStudent = await StudentService.GetStudentByIDNumber(s.Student.StudentIDNumber);

            subject.SubjectName = s.Subject.SubjectName;
            subject.SubjectDescription = s.Subject.SubjectDescription;
            subject.StudentID = currentStudent.StudentID;
            subject.UserID = User.GetUserId();

            //API CALL TO INSERT SUBJECT
            await SubjectService.InsertSubject(subject);
            return RedirectToAction("Currentstudents", "Student");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Currentstudents()
        {
            StudentSubjectVM obj = new StudentSubjectVM();
            int userID = User.GetUserId();
            var students = await StudentService.GetAllStudents(userID);
            obj.StudentSubjects = students;
            return View(obj);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Update(int StudentID)
        {
            StudentSubject obj = new StudentSubject();
            obj = await StudentService.GetStudentByID(StudentID);
            return View(obj);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(StudentSubject studentsubject)
        {
            var result = await StudentService.UpdateStudent(studentsubject);

            return RedirectToAction("Currentstudents", "Student");


        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int StudentID)
        {
            Student obj = new Student(); Subjects subject = new Subjects();
            var student = await StudentService.GetStudentByID(StudentID);
            var subjects = await SubjectService.GetAllSubjects();

            var getSubjectByStudentID = subjects.Where(x => x.StudentID == StudentID).FirstOrDefault();

            obj.StudentID = student.StudentID;
            obj.StudentFirstName = student.StudentFirstName;
            obj.StudentLastName = student.StudentLastName;
            obj.StudentIDNumber = student.StudentIDNumber;
            obj.StudentAddress = student.StudentAddress;
            obj.StudentMobile = student.StudentMobile;
            obj.StudentEmailAddress = student.StudentEmailAddress;
            obj.StudentAge = student.StudentAge;
            obj.StudentNumber = student.StudentNumber;
            obj.UserID = student.UserID;

            await StudentService.DeleteStudent(obj);
            await SubjectService.DeleteSubject(getSubjectByStudentID);

            return RedirectToAction("Currentstudents", "Student");
        }
    }
}
