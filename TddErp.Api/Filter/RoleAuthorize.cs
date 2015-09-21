using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TddErp.Api.Filter
{
    public class RoleAuthorize : AuthorizeAttribute
    {
        private static readonly string[] emptyArray = new string[0];
        private readonly object typeId = new object();
        private string roles;
        private string[] rolesSplit = emptyArray;
        private string users;
        private string[] usersSplit = emptyArray;

        new public string Roles
        {
            get { return roles ?? string.Empty; }
            set
            {
                roles = value;
                rolesSplit = SplitString(value);
            }
        }

        new public string Users
        {
            get { return users ?? string.Empty; }
            set
            {
                users = value;
                usersSplit = SplitString(value);
            }
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            if (SkipAuthorization(actionContext))
            {
                return;
            }

            if (!IsAuthorized(actionContext))
            {
                HandleUnauthorizedRequest(actionContext);
            }

            if (!IsAllowed(actionContext))
            {
                HandleForbiddenRequest(actionContext);
            }
        }

        internal static string[] SplitString(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return emptyArray;
            }

            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !string.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            IPrincipal user = HttpContext.Current.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return false;
            }

            return true;
        }

        protected bool IsAllowed(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            IPrincipal user = Thread.CurrentPrincipal;
            if (usersSplit.Length > 0 && !usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
            {
                return false;
            }

            if (rolesSplit.Length > 0 && !rolesSplit.Any(user.IsInRole))
            {
                return false;
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            HttpResponseMessage result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                RequestMessage = actionContext.Request
            };

            actionContext.Response = result;
        }

        protected void HandleForbiddenRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            HttpResponseMessage result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Forbidden,
                RequestMessage = actionContext.Request
            };

            actionContext.Response = result;
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}