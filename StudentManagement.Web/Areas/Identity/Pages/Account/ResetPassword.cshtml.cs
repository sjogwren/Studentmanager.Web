using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using StudentManagement.Interface;
using StudentManagement.Interface.IExternalUser;
using StudentManagement.Model;
using StudentManagement.Model.User;
using StudentManagement.Web.Api_Router;

namespace StudentManagement.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<ExternalUser> _userManager;
        private readonly IExternalUser _externalUserService;

        public ResetPasswordModel(UserManager<ExternalUser> userManager, IExternalUser externalUser)
        {
            _userManager = userManager;
            _externalUserService = externalUser;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Code { get; set; }
        }

        public IActionResult OnGet(string code = null)
        {
            if (code == null)
            {
                return BadRequest("A code must be supplied for password reset.");
            }
            else
            {
                Input = new InputModel
                {
                    Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
                };
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _externalUserService.FindByNameAsync(Input.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist
                    return RedirectToPage("./ResetPasswordConfirmation");
                }

                //var result = await _userManager.ResetPasswordAsync(user, Input.Code, Input.Password);
                user.PasswordHash = Security.HashPassword(Input.Password);
                var update = await _externalUserService.UpdateAsync(user);
                if (update == true)
                {
                    return RedirectToPage("./ResetPasswordConfirmation");
                }
            }
            catch
            {

                throw;
            }
            return Page();
        }
    }
}
