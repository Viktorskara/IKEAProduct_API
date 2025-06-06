namespace IKEAProduct_API.Models
{
    public class Colour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductColour> ProductColours { get; set; }
    }

}
