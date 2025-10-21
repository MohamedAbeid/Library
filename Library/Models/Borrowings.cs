using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Borrowings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }


        //[Required]
        //[ForeignKey("Users")]
        //public int UserId { get; set; }
        //public Users? Users { get; set; }


        [Required]
        [ForeignKey("Books")]
        public int BookId { get; set; }

        public Books? Books { get; set; }
    }
}
