using Library.Models;

namespace Library.ViewModel
{
    public class DahsBoardViewModel
    {
        StoryShelf context = new StoryShelf();

        public int TotalBooks => context.Books.Count();

        public int TotalUsers => context.Users.Count();

        public int TotalCategories => context.Categories.Count();

        public int TotalBorrowings => context.Borrowings.Count();
    }
}
