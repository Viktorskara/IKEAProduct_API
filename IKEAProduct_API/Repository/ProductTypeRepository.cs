using IKEAProduct_API.Data;
using IKEAProduct_API.Models;
using IKEAProduct_API.Repository.IRepository;

namespace IKEAProduct_API.Repository
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private readonly ApplicationDbContext _db;        
        public ProductTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }      
    }
}
