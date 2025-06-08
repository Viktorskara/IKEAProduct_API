using IKEAProduct_API.Data;
using IKEAProduct_API.Models;
using IKEAProduct_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IKEAProduct_API.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;        
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }      
    }
}
