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
            return View();
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
    }
}
