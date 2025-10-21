using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.ViewModel
{
    public class BooksViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        [RegularExpression(@"^.*\.(jpg|png|jpeg)$", ErrorMessage = "Only .jpg or .png or jpeg files are allowed")]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
