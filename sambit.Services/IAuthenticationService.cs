using sambit.BLL.Base;
using sambit.BLL.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sambit.BLL
{
    public interface IAuthenticationService : IEntityBase
    {
        BResult Authenticate(string email, string password);
        BResult ForgotPassword(string email);
        string CurrentUser();
    }
}
