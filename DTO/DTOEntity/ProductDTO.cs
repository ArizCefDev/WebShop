using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public int NumberCount { get; set; }
        public string Star { get; set; }
        public string Title { get; set; }
        [Range(1, 100)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryID { get; set; }
        public CategoryDTO CategoryDTO { get; set; }
		public int UserID { get; set; }
		public UserDTO UserDTO { get; set; }

	}
}
