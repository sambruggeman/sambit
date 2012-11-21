using sambit.BLL.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace sambit.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            private const string adminRole = Constants.RoleAdmin;
            private const string adminUserName = Constants.AdminUserName;
            private const string adminPassword = Constants.AdminPassword;

            public SimpleMembershipInitializer()
            {
                try
                {
                    WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection(Constants.ConnectionString, "UserProfiles", "Id", "UserName", autoCreateTables: true);

                    if (!Roles.RoleExists(adminRole))
                    {
                        Roles.CreateRole(adminRole);
                    }

                    if (!WebSecurity.UserExists(adminUserName))
                    {
                        WebSecurity.CreateUserAndAccount(adminUserName, adminPassword);
                    }

                    if (!Roles.IsUserInRole(adminUserName, adminRole))
                    {
                        Roles.AddUserToRole(adminUserName, adminRole);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}