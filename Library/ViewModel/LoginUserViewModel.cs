using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class LoginUserViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe  { get; set; }
    }
}
