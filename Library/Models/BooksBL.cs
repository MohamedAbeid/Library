using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Library.Models
{
    public class BooksBl
    {
        StoryShelf context = new StoryShelf();

        public List<BooksViewModel> GetAllBooks()
        {
            return context.Books
                .Select(b => new BooksViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Pages = b.Pages,
                    Image = b.Image,
                    AuthorName = b.Authors.Name,
                    CategoryName = b.Categories.Name
                })
                .ToList();
        }

        public Books GetBookById(int id)
        {
            return context.Books
                   .Include(b => b.Authors).Include(b => b.Categories)
                   .FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Books book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
        public void UpdateBook(Books book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }

        }
        public List<Books> GetBooksByCategoryId(int categoryId)
        {
            return context.Books
                          .Where(b => b.CategoryId == categoryId)
                          .ToList();
        }
        public List<Books> GetBooksByAuthorId(int authorId)
        {
            return context.Books
                          .Where(b => b.AuthorId == authorId)
                          .ToList();
        }
    }

}
