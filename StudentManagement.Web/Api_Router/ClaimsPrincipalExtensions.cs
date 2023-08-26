using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentManagement.Web.Api_Router
{
    public static class ClaimsPrincipalExtensions
    {

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }

        public static int GetUserId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal.FindFirst("ExternalUserID").Value);
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }
    }
}
