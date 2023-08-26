using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using StudentManagement.Interface;
using StudentManagement.Interface.IExternalUser;
using StudentManagement.Model;
using StudentManagement.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentManagement.Web.Areas.Identity
{
    public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ExternalUser>
    {
        private readonly IExternalUser _externalUser;

        public UserClaimsPrincipalFactory(UserManager<ExternalUser> userManager, IOptions<IdentityOptions> optionsAccessor, IExternalUser externalUser) : base(userManager, optionsAccessor)
        {
            _externalUser = externalUser;        
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ExternalUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var UserID = await _externalUser.FindByNameAsync(user.Email);
            int userID = UserID.ExternalUserID;
            identity.AddClaim(new Claim("ExternalUserID", $"{userID}"));
            identity.AddClaim(new Claim("FullName", $"{user.FirstName} {user.LastName}"));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            return identity;
        }
    }
}
