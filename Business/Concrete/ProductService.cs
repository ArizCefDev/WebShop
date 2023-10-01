using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.DTOEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService:BaseService<ProductDTO,Product,ProductDTO>,IProductService
    {
        public ProductService(IMapper mapper,AppDbContext appDbContext):base(mapper,appDbContext) 
        {
            
        }

        public IEnumerable<ProductDTO> GetAllWithInclude()
        {
            var post = _dbSet.Include(c => c.Category)
                             .Include(u => u.User).ToList();
            var rsdto = _mapper.Map<IEnumerable<ProductDTO>>(post);
            return rsdto;
        }
    }
}
