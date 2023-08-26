using Microsoft.Extensions.Configuration;
using System;

namespace StudentManagement.Web.Api_Router
{
    public static class UrlHelper
    {
        private static string GetUrl()
        {
            var config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .Build();

            return config.GetSection("WebApiUrl").GetSection("v1").Value;
        }

        public static class Api
        {
            public static Uri StudentManagementAPI => new Uri($"{GetUrl()}api/");
        }
     
        public static class Controller
        {
            public const string Student = "Student/";
            public const string Subject = "Subject/";
            public const string User = "User/";
        }

    }
}
