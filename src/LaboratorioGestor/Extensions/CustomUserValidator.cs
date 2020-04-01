using LaboratorioGestor.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LaboratorioGestor.App.ViewModels.Identity;
//using Microsoft.AspNetCore.Identity;

namespace LaboratorioGestor.App.Extensions
{
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {
        private static readonly Regex EmailRegex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public override async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager,  ApplicationUser user)
        {
            IdentityResult baseResult = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = new List<IdentityError>(baseResult.Errors);
            
            if (!EmailRegex.IsMatch(user.UserName))
            { 
                IdentityError invalidEmailError = Describer.InvalidEmail(user.UserName);
                invalidEmailError.Description += "O Nome o usário e inválido";
                errors.Add(invalidEmailError);
            }

            return errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }

    }
}