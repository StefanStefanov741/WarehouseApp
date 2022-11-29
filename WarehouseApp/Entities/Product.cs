namespace WarehouseApp.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float BuyPrice { get; set; }
        public float SellPrice { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
    }
}
