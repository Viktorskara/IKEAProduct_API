﻿using IKEAProduct_API.Data;
using IKEAProduct_API.Models;
using IKEAProduct_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IKEAProduct_API.Repository
{
    public class ColourRepository : Repository<Colour>, IColourRepository
    {
        private readonly ApplicationDbContext _db;        
        public ColourRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }      
    }
}
