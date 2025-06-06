namespace IKEAProduct_API.Models.Dto.ReadDTO
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public List<string> Colours { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
