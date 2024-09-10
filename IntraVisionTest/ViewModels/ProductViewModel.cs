namespace IntraVisionTest.MVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string BrandName { get; set; }
        public required string PhotoLink { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public  required List<string> BrandNames { get; set; }
    }
}
