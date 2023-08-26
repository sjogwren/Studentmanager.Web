using StudentManagement.Model.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Web.Api_Router
{
    public class SubjectService
    {
        public static async Task<List<Subjects>> GetAllSubjects()
        {
            return await RestApiHelper.GetAsync<List<Subjects>>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Subject}Subjects"));
        }

        public static async Task<Subjects> GetSubjectByID(int SubjectID)
        {
            return await RestApiHelper.GetAsync<Subjects>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Subject}GetById/{SubjectID}"));
        }

        public static async Task<Subjects> GetSubjectByName(string Name)
        {
            return await RestApiHelper.GetAsync<Subjects>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Student}GetSubjectByName/{Name}"));
        }

        public static async Task<bool> InsertSubject(Subjects model)
        {
            return await RestApiHelper.InsertAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Subject}Post/Insert"), model);
        }

        public static async Task<bool> UpdateSubject(Subjects model)
        {
            return await RestApiHelper.PutAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Subject}Update/Update"), model);
        }

        public static async Task<bool> DeleteSubject(Subjects model)
        {
            return await RestApiHelper.PutAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.Subject}Delete/Delete"), model);
        }
    }
}
