using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebProje.Models;

namespace MvcWebProje.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public AdminController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            List<User> users = new List<User>();
            List<UserModel> usersModel = new List<UserModel>();

            usersModel = _databaseContext.Users.Select(x => new UserModel { Id = x.Id, Username = x.Username, Email = x.Email, CreatedAt = x.CreatedAt, Role = x.Role }).ToList();

            return View(usersModel);
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserModel model)
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

                var userdata = new User()
                {
                    Username = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role,
                };
                _databaseContext.Users.Add(userdata);
                _databaseContext.SaveChanges();
                return RedirectToAction("Index", "User");
            }

            return View(model);
        }
        public IActionResult DeleteUser(Guid id)
        {
            User user = _databaseContext.Users.Find(id);

            if (user != null)
            {
                _databaseContext.Users.Remove(user);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult EditUser(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _databaseContext.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(Guid id, EditUserModel edit)
        {
            if (id != edit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var use = _databaseContext.Users.Find(id);
                if (ModelState.IsValid)
                {
                    use.Username = edit.Username;
                    use.Email = edit.Email;
                    use.Role = edit.Role;
                    _databaseContext.Users.Update(use);
                    _databaseContext.SaveChanges();
                }
                return RedirectToAction("Index", "User");
            }

            return View(edit);
        }
        public IActionResult YemekTarifiGoruntule()
        {
            List<Yemekler> yemek = new List<Yemekler>();

            // yemek = _databaseContext.yemeklers.Select(x => new Yemekler { id = x.id, yemekIsmi = x.yemekIsmi, yemeginKategorisi = x.yemeginKategorisi, YemekTarifi = x.YemekTarifi, CreatedAt = x.CreatedAt }).ToList();
            yemek = _databaseContext.yemeklers.ToList();
            return View(yemek);
        }
        public IActionResult CreateYemek()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateYemek(yemekViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.yemeklers.Any(x => x.yemekIsmi.ToLower() == model.yemekIsmi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.yemekIsmi), "yemekIsmi is already exists");
                    return View(model);
                }

                var userdata = new Yemekler()
                {
                    yemekIsmi = model.yemekIsmi,
                    yemeginKategorisi = model.yemeginKategorisi,
                    YemekTarifi = model.YemekTarifi,
                    CreatedAt = model.CreatedAt,
                };
                _databaseContext.yemeklers.Add(userdata);
                _databaseContext.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }
        public IActionResult DeleteYemek(int id)
        {
            Category category = _databaseContext.Categories.Find(id);

            if (category != null)
            {
                _databaseContext.Categories.Remove(category);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult iletisimGoruntule()
        {
            List<iletisim> iletisim = new List<iletisim>();

            // yemek = _databaseContext.yemeklers.Select(x => new Yemekler { id = x.id, yemekIsmi = x.yemekIsmi, yemeginKategorisi = x.yemeginKategorisi, YemekTarifi = x.YemekTarifi, CreatedAt = x.CreatedAt }).ToList();
            iletisim = _databaseContext.iletisims.ToList();
            return View(iletisim);
        }
        public IActionResult DeleteIletisim(int id)
        {
            iletisim iletisim = _databaseContext.iletisims.Find(id);

            if (iletisim != null)
            {
                _databaseContext.iletisims.Remove(iletisim);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction("iletisimGoruntule", "Admin");
        }
    }
}
