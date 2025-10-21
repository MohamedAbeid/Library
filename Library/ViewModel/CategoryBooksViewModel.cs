using Library.Models;

namespace Library.ViewModel
{
    public class CategoryBooksViewModel
    {
        public Categories Category { get; set; }
        public List<Books> Books { get; set; }
    }
}
