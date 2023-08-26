using StudentManagement.Model.Subjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.ISubject
{
    public interface ISubject
    {
        bool Post(Subjects e);
        void Put(Subjects e);
        Task<Subjects> GetSubjectById(int Id);
        Task<Subjects> GetSubjectByName(string Name);
        Task<List<Subjects>> GetAllSubjects();
        void Delete(Subjects e);
        Task<bool> SaveAllAsync();
    }
}
