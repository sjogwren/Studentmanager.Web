using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using StudentManagement.Interface.IExternalUser;
using StudentManagement.Model.User;
using StudentManagement.Web.Models;

namespace StudentManagement.Web.Api_Router
{
    public class ExternalUserService : IExternalUser
    {

        /// <summary>
        /// Gets the user by their username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns a single user</returns>
        public async Task<ExternalUser> FindByNameAsync(string username)
        {
            return await Connection.GetAsync<ExternalUser>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.User}GetByUsername/{username}"));
        }

        /// <summary>
        /// Creates a new user and returns the user object
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a user object</returns>
        public async Task<bool> CreateAsync(ExternalUser user)
        {
            return await Connection.InsertAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.User}CreateAsync/Insert"), user);
        }

        /// <summary>
        /// Creates a new user and returns a UserID
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a UserID</returns>
        public async Task<long> Post(ExternalUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a boolean</returns>
        public async Task<bool> UpdateAsync(ExternalUser user)
        {
            return await Connection.PutAsync(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.User}Put/Update"), user);
        }

        /// <summary>
        /// Gets the user by their UserID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns a single user</returns>
        public async Task<ExternalUser> FindByIdAsync(int userId)
        {
            return await Connection.GetAsync<ExternalUser>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.User}GetByUserId/{userId}"));
        }

        /// <summary>
        /// Gets all the users including locked out users
        /// </summary>
        /// <returns>Returns a list of users</returns>
        public async Task<List<ExternalUser>> GetAllUsersInclLockedOut()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckIfEmailExist(string email)
        {
            return await Connection.GetAsync<bool>(new Uri(UrlHelper.Api.StudentManagementAPI, $"{UrlHelper.Controller.User}CheckIfEmailExist/{email}"));
        }
    }
}