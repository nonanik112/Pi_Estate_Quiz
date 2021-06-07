using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pi_Estate.Identity;
using Pi_Estate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pi_Estate.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        public ActionResult SifreDegistir()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult SifreDegistir(SifreDegistir model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.ChangePassword(User.Identity.GetUserId(), model.Oldpassword, model.NewPassword);
                return View("Updae");
            }
            return View(model);
        }
          //get
        public ActionResult  Profil()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();//giriş yapan kullancıı id
            var user = UserManager.FindById(id);
            var data = new ProfilGuncelleme()
            {
                id=user.Id,
                name=user.Name,
                username=user.UserName,
                surname=user.SurName,
                email=user.Email
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult Profil(ProfilGuncelleme model )
        {
            var user = UserManager.FindById(model.id);
            user.Name = model.name;
            user.SurName = model.surname;
            user.UserName = model.username;
            user.Email = model.email;
            UserManager.Update(user);
            return View("Update");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.UserName, model.Password);
                if (user!=null)
                {
                    var authmanager = HttpContext.GetOwinContext().Authentication;
                    var identitiyclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authmanager.SignIn(authProperties, identitiyclaims);
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle Bir Kullanıcı Bulunmamaktadır.");
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            var authmanager = HttpContext.GetOwinContext().Authentication;
            authmanager.SignOut();
            return RedirectToAction("Index","Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.UserName = model.UserName;
                user.SurName = model.SurName;
                user.Email = model.Email;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullancıı Oluşturma Hatası");
                }
            }
            return View(model);
        }
        // GET: Account
        public ActionResult Index()
        {
            
            return View();
        }
    }
}