using EasyResto.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyResto.Middleware
{
    public class AuthPrivilegeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Privilege { get; }

        public AuthPrivilegeAttribute(string privilege)
        {
            Privilege = privilege;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            List<string> privileges = Privilege.Split(',').Select(privilege => privilege.Trim()).ToList();
            if (!context.HttpContext.User.HasClaim(c => c.Type == AuthCode.Privilege.ToString() && privileges.Contains(c.Value)))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
