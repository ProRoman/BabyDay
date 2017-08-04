using BabyDay.Models;
using BabyDay.Models.Entity;
using BabyDay.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BabyDay.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private IAuthenticationManager _authenticationManager;

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
        }

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

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Signup(SignupData signupData)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = signupData.Username, Email = signupData.Email };
                var result = await _userManager.CreateAsync(user, signupData.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(signupData);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}