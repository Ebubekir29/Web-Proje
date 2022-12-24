using Microsoft.AspNetCore.Mvc;
using MvcWebProje.Models;

namespace MvcWebProje.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public UserController(DatabaseContext databaseContext)
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
        //public IActionResult EditUser(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = _databaseContext.Users.Find(id);

        //    var viewModel = _databaseContext.Users.Select(x => new EditViewModel { UserName = x.Username, Email = x.Email, Role = x.Role, Locked = x.Locked });
        //    return View(viewModel);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditUser(Guid id, EditUserModel edit)
        //{
        //    if (id != edit.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var use = _databaseContext.Users.Find(id);
        //        if (ModelState.IsValid)
        //        {
        //            use.Username = edit.Username;
        //            use.Email = edit.Email;
        //            use.Role = edit.Role;
        //            use.Locked = edit.Locked;
        //            _databaseContext.Users.Update(use);
        //            _databaseContext.SaveChanges();
        //        }
        //        return RedirectToAction("Index", "User");
        //    }

        //    return View(edit);
        //}

    }
}
