using myApp.Business.Services;
using myApp.Cloud.Business.DesignPattern.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myApp.Cloud.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFollowService _followService;

        public HomeController(
            IUserService userService,
            IFollowService followService
        )
        {
            _userService = userService;
            _followService = followService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
