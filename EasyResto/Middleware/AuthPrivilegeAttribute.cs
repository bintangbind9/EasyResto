using EasyResto.Domain.Common;
using EasyResto.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

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
                var response = new BaseResponse<string>();
                response.Status = (int)HttpStatusCode.Unauthorized;
                response.Title = "Unauthorized";
                response.Message = "You are not authorized";
                response.Errors = new List<string> { "You are not authorized" };

                context.Result = new ObjectResult(response) { StatusCode = (int)HttpStatusCode.Unauthorized };
                return;
            }

            List<string> privileges = Privilege.Split(',').Select(privilege => privilege.Trim()).ToList();
            if (!context.HttpContext.User.HasClaim(c => c.Type == AuthCode.Privilege.ToString() && privileges.Contains(c.Value)))
            {
                var response = new BaseResponse<string>();
                response.Status = (int)HttpStatusCode.Forbidden;
                response.Title = "Forbidden";
                response.Message = "You don't have permission";
                response.Errors = new List<string> { "You don't have permission" };

                context.Result = new ObjectResult(response) { StatusCode = (int)HttpStatusCode.Forbidden };
                return;
            }
        }
    }
}
