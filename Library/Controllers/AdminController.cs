using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        BooksBl booksBl = new BooksBl();
        StoryShelf context = new StoryShelf();
        CategoriesBL categoriesBL = new CategoriesBL();
        AuthorsBL authorsBL = new AuthorsBL();


        public IActionResult Index(DahsBoardViewModel vm)
        {
            return View(vm);
        }
        public IActionResult Books()
        {
            var books = booksBl.GetAllBooks();
            return View(books);
        }
        public IActionResult Categories()
        {
            var categories = categoriesBL.GetAllCategory();
            return View(categories);
        }
        public IActionResult Authors()
        {
            var authors = authorsBL.GetAllAuthors();
            return View(authors);
        }


    }


}
