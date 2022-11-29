

using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "This field is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
