using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.ProductDTOs
{
    public class ProductToUpdateDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Price { get; set; }
        public int Raiting { get; set; }
        public string Description { get; set; }
        public bool IsTrending { get; set; }
        public bool IsFeatured { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
    }
}
