using System.Collections.Generic;
using WarehouseApp.Entities;

namespace WarehouseApp.Models
{
    public class InventorySearchVM
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public List<Product>products { get; set; }
        public List<Product> all_products { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
    }
}
