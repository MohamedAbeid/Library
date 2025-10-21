using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Authors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]

        public string Name { get; set; }
        public ICollection<Books>? Books { get; set; }

    }
}
