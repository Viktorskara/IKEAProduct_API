namespace IKEAProduct_API.Models.Dto.ReadDTO
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductTypeDTO ProductType { get; set; }
        public List<ColourDTO> Colours { get; set; } // I changed this from public List<string> Colours { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
