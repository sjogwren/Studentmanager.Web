using StudentManagement.Model.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.IStudent
{
    public interface IStudents
    {
        bool Post(Student e);
        void Put(Student e);
        Task<Student> GetStudentById(int Id);
        Task<List<Student>> GetAllStudents();
        void Delete(Student e);
        Task<bool> SaveAllAsync();
        Task<Student> GetStudentByIdNumber(string Id);
    }
}
