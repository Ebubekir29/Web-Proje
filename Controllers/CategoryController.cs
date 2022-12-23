using Microsoft.AspNetCore.Mvc;
using MvcWebProje.Models;

namespace MvcWebProje.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public CategoryController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();

            categories = _databaseContext.Categories.Select(x => new Category { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
            return View(categories);
        }
        public IActionResult Index1()
        {
            List<Category> categories = new List<Category>();

            categories = _databaseContext.Categories.Select(x => new Category { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Categories.Any(x => x.Name.ToLower() == model.Name.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Name), "Name is already exists");
                    return View(model);
                }

                var userdata = new Category()
                {
                    Name = model.Name,
                    Description = model.Description,
                };
                _databaseContext.Categories.Add(userdata);
                _databaseContext.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(model);
        }
        public IActionResult DeleteCategory(int id)
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
