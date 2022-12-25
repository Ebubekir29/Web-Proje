using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebProje.Models;
using System.Diagnostics;

namespace MvcWebProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _databaseContext;
        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Hakkında()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult iletisim()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult iletisim(iletisim model)
        {
            if (ModelState.IsValid)
            {
                iletisim iletisim = new()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Description = model.Description
                };
                _databaseContext.iletisims.Add(iletisim);
                int affectedRowCount = _databaseContext.SaveChanges();
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "iletisim can not be added.");
                }
                else
                {
                    return RedirectToAction(nameof(iletisim));
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}