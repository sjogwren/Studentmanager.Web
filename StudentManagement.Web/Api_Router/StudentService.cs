using StudentManagement.Model.Student;
using StudentManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Web.Api_Router
{
    public class StudentService
    {
        public static async Task<List<StudentSubject>> GetAllStudents(int UserId)
        {
            return await RestApiHelper.GetAsync<List<StudentSubject>>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Student}Students/{UserId}"));
        }

        public static async Task<StudentSubject> GetStudentByID(int StudentID)
        {
            return await RestApiHelper.GetAsync<StudentSubject>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Student}GetById/{StudentID}"));
        }

        public static async Task<Student> GetStudentByIDNumber(string ID)
        {
            return await RestApiHelper.GetAsync<Student>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Student}GetStudentByIdNumber/{ID}"));
        }
        public static async Task<bool> InsertStudent(Student model)
        {
            return await RestApiHelper.InsertAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Student}Post/Insert"), model);
        }

        public static async Task<bool> UpdateStudent(StudentSubject model)
        {
            return await RestApiHelper.PutAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Student}Update/Update"), model);
        }

        public static async Task<bool> DeleteStudent(Student model)
        {
            return await RestApiHelper.PutAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Student}Delete/Delete"), model);
        }
    }
}
