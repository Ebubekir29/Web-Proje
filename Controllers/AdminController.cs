using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebProje.Models;

namespace MvcWebProje.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult YemekTarifiGoruntule()
        {
            List<yemekViewModel> yemek = new List<yemekViewModel>();

            yemek = _databaseContext.yemeklers.Select(x => new yemekViewModel { id = x.id, yemekIsmi = x.yemekIsmi, yemeginKategorisi = x.yemeginKategorisi, YemekTarifi = x.YemekTarifi, CreatedAt = x.CreatedAt }).ToList();

            return View(yemek);
        }
        public IActionResult YemekTarifiEkle()
        {
            return View();
        }
    }
}
