using BabyDay.Models;
using BabyDay.Models.Entity;
using BabyDay.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BabyDay.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IUserStore<ApplicationUser> _applicationUserStore;

        public HomeController(ApplicationUserManager userManager,
            ApplicationSignInManager signInManager,
            IAuthenticationManager authenticationManager,
            IUserStore<ApplicationUser> applicationUserStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _applicationUserStore = applicationUserStore;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Signin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signin(string returnUrl, SigninData signinData)
        {
            if (!ModelState.IsValid)
            {
                return View(signinData);
            }

            ApplicationUser signedUser = _userManager.FindByEmail(signinData.Email);

            if (signedUser == null)
            {
                ModelState.AddModelError("Notfound", "The user not found");
                return View(signinData);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(signedUser.UserName, signinData.Password, signinData.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                default:
                    ModelState.AddModelError("SignInFail", "Invalid login attempt.");
                    return View(signinData);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Signup(SignupData signupData)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = signupData.Username, Email = signupData.Email };
                var result = await _userManager.CreateAsync(user, signupData.Password);
                if (result.Succeeded)
                {
                    // If isPersistent is set to false, the browser will acquire session cookie which gets cleared when the browser is closed.
                    // rememberBrowser is relevant only in Two-factor authentication
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    ((ApplicationUserStore)_applicationUserStore).Context.Set<Parent>().Add(new Parent() { UserProfile = user });

                    ((ApplicationUserStore)_applicationUserStore).SaveOrUpdate();

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
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AddChild()
        {
            ApplicationUser profile = ((ApplicationUserStore)_applicationUserStore).Context.Set<ApplicationUser>().First(e => e.Id.Equals(User.Identity.GetUserId()));
            return RedirectToAction("Index", "Home");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}