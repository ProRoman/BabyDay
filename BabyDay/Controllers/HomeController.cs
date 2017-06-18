using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BabyDay.Models;

namespace BabyDay.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(Account account)
        {
            return View(account);
        }

        [HttpPost]
        public ActionResult Signup(Account account)
        {
            return View();
        }
    }
}