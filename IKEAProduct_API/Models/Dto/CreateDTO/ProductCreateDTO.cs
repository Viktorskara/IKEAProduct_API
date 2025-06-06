namespace IKEAProduct_API.Models.Dto
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public List<int> ColourIds { get; set; }
    }
}
