using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthorsController : Controller
    {
        AuthorsBL authorsBL = new AuthorsBL();
        BooksBl booksBl = new BooksBl();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var authors = authorsBL.GetAllAuthors();
            return View(authors);
        }
        [AllowAnonymous]
        public IActionResult GetAuthor(int id)
        {
            var authors = authorsBL.GetAuthorsById(id);
            if (authors == null) return NotFound();

            var books = booksBl.GetBooksByAuthorId(id);

            var vm = new AuthorsBooksViewModel
            {
                Author = authors,
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
        public IActionResult Create(Authors authors)
        {
            if (ModelState.IsValid)
            {
                authorsBL.AddAuthors(authors);
                return RedirectToAction("Authors", "Admin");
            }
            return View(authors);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var authors = authorsBL.GetAuthorsById(id);
            if (authors == null) return NotFound();
            return View(authors);
        }
        [HttpPost]
        public IActionResult Edit(Authors authors)
        {
            if (ModelState.IsValid)
            {
                authorsBL.UpdateAuthors(authors);
                return RedirectToAction("Authors", "Admin");
            }
            return View(authors);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        { 
            authorsBL.DeleteAuthors(id);
            return RedirectToAction("Authors", "Admin");
        }
    }
}
