using System.Collections.Generic;
using WarehouseApp.Entities;

namespace WarehouseApp.Models
{
    public class deleteProdModel
    {
        public string CodeToDel { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public List<Product>products { get; set; }
    }
}
