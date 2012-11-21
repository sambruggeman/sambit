using sambit.DAL.Entities;
using sambit.DAL.Repositories;
using sambit.BLL.Base;
using sambit.BLL.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebMatrix.WebData;
using System.Web.Security;
using sambit.BLL.Entities.Base;

namespace sambit.BLL.Entities
{
    public class AuthenticationService : EntityBase, IAuthenticationService
    {
        private readonly IRepository<Post> _repository;

        public AuthenticationService(IRepository<Post> repository)
        {
            this._repository = repository;
            this._result = new BResult();
        }

        public BResult Authenticate(string email, string password)
        {
            if (WebSecurity.Login(email, password))
            {
                MembershipUser mUser = Membership.GetUser();
                _result.EntityId = WebSecurity.CurrentUserId;
                return _result;
            }
            else
            {
                _result.AddError("AuthenticationError", "Wrong username and/or password");
                return _result;
            }
        }

        public string CurrentUser()
        {
            return Membership.GetUser().UserName;
        }

        public BResult ForgotPassword(string email)
        {
            string token = WebSecurity.GeneratePasswordResetToken(email);
            
            throw new NotImplementedException();
        }
    }
}
