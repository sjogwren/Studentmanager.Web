using StudentManagement.Model.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interface.IExternalUser
{
    public interface IExternalUser
    {
        Task<ExternalUser> FindByNameAsync(string username);
        Task<bool> CreateAsync(ExternalUser user);
        Task<bool> UpdateAsync(ExternalUser user);
        Task<ExternalUser> FindByIdAsync(int userId);
        Task<bool> CheckIfEmailExist(string email);
    }
}
