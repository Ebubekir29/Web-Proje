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
            List<Yemekler> yemek = new List<Yemekler>();
            yemek = _databaseContext.yemeklers.Select(x => new Yemekler { id = x.id, yemekIsmi = x.yemekIsmi, yemeginKategorisi = x.yemeginKategorisi, YemekTarifi = x.YemekTarifi, CreatedAt = x.CreatedAt }).ToList();
            return View(yemek);
        }

        [HttpGet]
        public IActionResult FoodDetail(string foodid)
        {
            Yemekler yemek = _databaseContext.yemeklers.FirstOrDefault(x => x.id.ToString() == foodid);
            ViewBag.yemek = yemek;
            var commends = (from k in _databaseContext.commends
                            where yemek.id.ToString() == k.yemekid
                            select new Commend() { id = k.id, Yorum = k.Yorum, Userid = k.Userid, Username = k.Username, yemekid = k.yemekid }).ToList();
            ViewBag.commends = commends;
            var userid = Request.Cookies["id"];
            var user = _databaseContext.Users.FirstOrDefault(x => x.Id.ToString() == userid);
            ViewBag.user = user;
            return View(new Commend());
        }
        [HttpPost]
        public IActionResult NewComment(Commend commend)
        {
            _databaseContext.commends.Add(commend);
            _databaseContext.SaveChanges();
            return RedirectToAction("FoodDetail", new { foodid = commend.yemekid });
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