using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Library.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BooksController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public BooksController(IWebHostEnvironment env)
        {
            _env = env;
        }

        BooksBl booksBl = new BooksBl();
        StoryShelf context = new StoryShelf();

        [AllowAnonymous]
        public IActionResult Index()
        {
            var books = booksBl.GetAllBooks();
            return View(books);
        }
        [AllowAnonymous]

        public IActionResult GetBook(int id)
        {
            var book = booksBl.GetBookById(id);
            if (book == null) return NotFound();

            var vm = new BooksViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Pages = book.Pages,
                Image = book.Image,
                AuthorName = book.Authors.Name,
                CategoryName = book.Categories.Name

            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Authors"] = context.Authors.ToList();
            ViewData["Dep"] = context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Books book)
        {
            if (ModelState.IsValid)
            {
                if (book.ImageFile != null)
                {
                    var extension = Path.GetExtension(book.ImageFile.FileName).ToLower();

                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                    {
                        ModelState.AddModelError("ImageFile", "Only .jpg or .png files are allowed");
                        ViewData["Authors"] = context.Authors.ToList();
                        ViewData["Dep"] = context.Categories.ToList();
                        return View(book);
                    }

                    string fileName = Guid.NewGuid().ToString() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        book.ImageFile.CopyTo(stream);
                    }

                    book.Image = fileName;
                }
                else
                {
                    ModelState.AddModelError("ImageFile", "The Image field is required.");
                    ViewData["Authors"] = context.Authors.ToList();
                    ViewData["Dep"] = context.Categories.ToList();
                    return View(book);
                }

                booksBl.AddBook(book);
                return RedirectToAction("Books", "Admin");
            }

            ViewData["Authors"] = context.Authors.ToList();
            ViewData["Dep"] = context.Categories.ToList();
            return View(book);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            ViewData["Authors"] = context.Authors.ToList();
            ViewData["Dep"] = context.Categories.ToList();


            return View(booksBl.GetBookById(id));
        }
        [HttpPost]
        public IActionResult Edit(Books book)
        {
            ViewData["Authors"] = context.Authors.ToList();
            ViewData["Dep"] = context.Categories.ToList();

            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var existingBook = booksBl.GetBookById(book.Id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Pages = book.Pages;
            existingBook.AuthorId = book.AuthorId;
            existingBook.CategoryId = book.CategoryId;

            if (book.ImageFile != null && book.ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(book.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    book.ImageFile.CopyTo(stream);
                }

                existingBook.Image = fileName; 
            }

            booksBl.UpdateBook(existingBook);

            return RedirectToAction("Books", "Admin");
        }

        public IActionResult Delete(int id)
        {
            booksBl.DeleteBook(id);
            return RedirectToAction("Books", "Admin");
        }

    }
}
