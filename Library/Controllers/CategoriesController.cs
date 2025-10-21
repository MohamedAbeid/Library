using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.ComponentModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CategoriesController : Controller
    {
        CategoriesBL categoriesBL = new CategoriesBL();
        BooksBl booksBl = new BooksBl();
        StoryShelf context = new StoryShelf();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var category = categoriesBL.GetAllCategory();
            return View(category);
        }
        [AllowAnonymous]

        public IActionResult GetCategory(int id)
        {
            var category = categoriesBL.GetCategoryById(id);
            if (category == null) return NotFound();

            var books = booksBl.GetBooksByCategoryId(id);

            var vm = new CategoryBooksViewModel
            {
                Category = category,
                Books = books
            };

            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories category)
        {
            if (ModelState.IsValid)
            {
                categoriesBL.AddCategory(category);
                return RedirectToAction("Categories", "Admin");
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoriesBL.GetCategoryById(id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Categories category)
        {
            if (ModelState.IsValid)
            {
                categoriesBL.UpdateCategory(category);
                return RedirectToAction("Categories", "Admin");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = context.Categories
        .Include(c => c.Books) 
        .FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            if (category.Books.Any())
            {
                return Content("Cannot delete the category because it contains books");
            }
            categoriesBL.DeleteCategory(id);
            return RedirectToAction("Categories", "Admin");
        }
    }
}
