using Delloite.TaskManager.Services;
using System;
using System.Text;
using System.Web.Mvc;

namespace TaskManager.UI.Web.App_Start
{
    public class ValidationToken : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            ///validation token
            try
            {
                var token = filterContext.HttpContext.Request.Headers["Authorization"];

                if (String.IsNullOrWhiteSpace(token))
                    HandleUnauthorizedRequest(filterContext);

                var credentials = this.GetCredentials(token);
              
                var userService = new UserService();
                var userSession = userService.GetUser(credentials[0], credentials[1]);
                if (userSession.token != token)
                {
                    HandleUnauthorizedRequest(filterContext);
                }                       
                
            }
            catch
            {               
                HandleUnauthorizedRequest(filterContext);
            }           

        }

        private string[] GetCredentials(string token)
        {
            var credentials = Encoding.GetEncoding("ISO-8859-1").GetString(Convert.FromBase64String(token));
            return credentials.Split(':');
        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                base.HandleUnauthorizedRequest(filterContext);
            else
            {               
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.HttpContext.Response.StatusCode = 403;

            }
        }

    }
}