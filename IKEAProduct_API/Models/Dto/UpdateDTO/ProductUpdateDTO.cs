namespace IKEAProduct_API.Models.Dto
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductTypeName { get; set; }
        public List<string> ProductColours { get; set; }
    }
}
