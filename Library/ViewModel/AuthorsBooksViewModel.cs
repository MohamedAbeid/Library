using Library.Models;

namespace Library.ViewModel
{
    public class AuthorsBooksViewModel
    {
        public Authors Author { get; set; }
        public List<Books> Books { get; set; }
    }
}
