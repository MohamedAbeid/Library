using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Users : IdentityUser
    {
        //public int Id { get; set; }
        //[Required]
        //[MinLength(2)]
        //[MaxLength(50)]
        //public string Name { get; set; }
        //[Required]
        //[MinLength(2)]
        //[MaxLength(30)]
        //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")] 
        
        //public string Email { get; set; }


        //[Required]
        //[DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
        //public string Password { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        //public string PasswordConf { get; set; }

        //[Required]
        //[RegularExpression("^(User|Admin)$", ErrorMessage = "Role must be either User, or Admin.")]
        //public string Role { get; set; } = "User";

        public ICollection<Borrowings>? Borrowings { get; set; }



    }
}
