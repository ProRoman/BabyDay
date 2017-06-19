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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(SigninData signinData)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View();
            }
        }
        
        public ActionResult Signup()
        {
            return View();
        }
    }
}