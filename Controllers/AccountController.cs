using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebProje.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MvcWebProje.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public AccountController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }
        [AllowAnonymous] // Girişlere izin verir
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {


                User user = _databaseContext.Users.SingleOrDefault(x => x.Username.ToLower() == model.UserName.ToLower() && x.Password == model.Password);

                if (user != null)
                {
                    //if (user.Locked)
                    //{
                    //    ModelState.AddModelError("", "UserName or password is incorrect");
                    //    return View(model);
                    //}


                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.Email ?? String.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));

                    claims.Add(new Claim("userName", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    Response.Cookies.Append("id", user.Id.ToString());

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "UserName or password is incorrect");
                }
            }
            return View(model);
        }

        //private string DoMD5HashedString(string s)
        //{
        //    string md5salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
        //    string salted = s + md5salt;
        //    string hashed = salted.MD5();
        //    return hashed;
        //}

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.UserName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.UserName), "UserName is already exists");
                    return View(model);
                }
                else if (_databaseContext.Users.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Email), "Email is already exists");
                    return View(model);
                }

                //string hashedPassword = DoMD5HashedString(model.Password);
                User user = new()
                {
                    Username = model.UserName,
                    Email = model.Email,
                    Password = model.Password
                };
                _databaseContext.Users.Add(user);
                int affectedRowCount = _databaseContext.SaveChanges();
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "User can not be added.");
                }
                else
                {
                    return RedirectToAction(nameof(user));
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Profile()
        {
            ProfileViewData();
            return View();
        }

        private void ProfileViewData()
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

            ViewData["Email"] = user.Email;
        }

        //public IActionResult ProfileChangeFullName(Guid id, EditUserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
        //        {
        //            ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
        //            return PartialView("_EditUserPartial", model);
        //        }

        //        User user = _databaseContext.Users.Find(id);

        //        _mapper.Map(model, user);
        //        _databaseContext.SaveChanges();

        //        return PartialView("_EditUserPartial");
        //    }

        //    return PartialView("_EditUserPartial", model);
        //}
        [HttpPost]
        public IActionResult ProfileEdit([Required][MinLength(6)][MaxLength(16)] string? userName, string? password, string? email)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);


                //string hashedPassword = DoMD5HashedString(password);


                user.Username = userName;
                user.Email = email;
                user.Password = password;
                _databaseContext.SaveChanges();

                ViewData["result"] = "PasswordChanged";
            }
            ProfileViewData();
            return View("Profile");
        }
        public IActionResult iletisim()
        {
            ProfileViewData();
            return View();
        }

        //iletisim yapılmadı....
        //public IActionResult iletisim(iletisim ilet)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        iletisim iletisim = new()
        //        {
        //            Ad = ilet.Ad,
        //            Soyad = ilet.Soyad,
        //            Email = ilet.Email,
        //            Mesaj = ilet.Mesaj,
        //            Tarih = DateTime.Now
        //        };
        //        _databaseContext.iletisims.Add(iletisim);
        //        _databaseContext.SaveChanges();
        //        return RedirectToAction("Iletisim");
        //    }
        //    return View();
        //}
    }
}
