using System.ComponentModel.DataAnnotations;

namespace IKEAProduct_API.Models.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductTypeDTO ProductType { get; set; }
        public List<ColourDTO> Colours { get; set; }
    }
}
