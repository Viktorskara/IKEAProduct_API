namespace IKEAProduct_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<ProductColour> ProductColours { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
