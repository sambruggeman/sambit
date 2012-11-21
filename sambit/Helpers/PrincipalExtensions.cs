using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using sambit.Attributes;

namespace sambit.Helpers
{
    public static class PrincipalExtensions
    {
        public static bool IsInRole(this IPrincipal user, AppRole appRole)
        {
            var roles = appRole.ToString().Split(',').Select(x => x.Trim());
            foreach (var role in roles)
            {
                if (user.IsInRole(role))
                    return true;
            }

            return false;
        }
    }
}