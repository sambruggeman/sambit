using sambit.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sambit.Attributes;
using sambit.BLL;

namespace sambit.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IAuthenticationService _authenticationService;

        public HomeController(IPostService postService, IAuthenticationService authenticationService)
        {
            this._postService = postService;
            this._authenticationService = authenticationService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //_postService.AddPost("firstpost", "text in first post");            
            //var post = _postService.GetLastPost();
            //var login = _authenticationService.Authenticate("sam@sambit.be", "secret");

            return View();
        }

        //[MyAuthorize(AppRole = AppRole.Admin)]
        [AllowAnonymous]
        public ActionResult About()
        {
            //var test4 = _authenticationService.CurrentUser();
            //var test = Request.LogonUserIdentity.Name;
            //var test2 = Request.LogonUserIdentity.IsAuthenticated;
            //var test3 = new System.Security.Principal.WindowsPrincipal(Request.LogonUserIdentity).IsInRole(AppRole.Admin.ToString());

            ViewBag.Message = "Your app description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            //_authenticationService.Authenticate("sam@sambit.be", "secret");

            return View();
        }
    }
}
