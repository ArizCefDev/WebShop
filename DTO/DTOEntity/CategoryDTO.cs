using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ProductDTO> ProductDTOs { get; set; }
    }
}
