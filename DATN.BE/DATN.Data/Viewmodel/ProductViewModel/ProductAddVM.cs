namespace DATN.Data.Viewmodel.ProductViewModel
{
    public class ProductAddVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Sale { get; set; }
        public int Inventory { get; set; }
        public int Insurance { get; set; }
        public string Accessory { get; set; }
        public string Sensor { get; set; }
        public string ImageProcessor { get; set; }
        public float Screen { get; set; }
        public string ISO { get; set; }
        public string ShutterSpeed { get; set; }
        public string ProductSummary { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}