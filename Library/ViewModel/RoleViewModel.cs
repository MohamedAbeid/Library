using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
