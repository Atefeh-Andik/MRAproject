using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRAproject.Models
{
    public class SessionBasedAuthorizeAttribute : AuthorizeAttribute
    {
        public Role.Type Role { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session[StaticS.UserSession] == null ||
                 ((Admin)System.Web.HttpContext.Current.Session[StaticS.UserSession]).Role.ID != Role)
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}