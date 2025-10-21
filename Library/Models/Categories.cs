using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]

        // UNIQUE
        public string Name { get; set; }

        public ICollection<Books>? Books { get; set; }
    }
}
