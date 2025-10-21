using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        public int Pages { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please upload an image")]
        public IFormFile ImageFile { get; set; }

        [Required]
        [ForeignKey("Authors")]
        public int AuthorId { get; set; }


        [Required]
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        public Authors? Authors { get; set; }
        public Categories? Categories { get; set; }

        public ICollection<Borrowings>? Borrowings { get; set; }


    }
}
