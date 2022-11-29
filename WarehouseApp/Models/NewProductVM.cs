using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models
{
    public class NewProductVM
    {
        [Required(ErrorMessage = "This field is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public float BuyPrice { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public float SellPrice { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string Category { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public string Code { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
