using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace sambit.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public AppRole AppRole { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AppRole != 0)
                Roles = AppRole.ToString();

            base.OnAuthorization(filterContext);
        }
    }

    [Flags]
    public enum AppRole
    {
        Admin = 1,
        Contributor = 2,
        User = 4
    }
}
