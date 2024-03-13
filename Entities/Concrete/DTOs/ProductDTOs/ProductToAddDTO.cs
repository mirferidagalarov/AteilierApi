using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.ProductDTOs
{
    public class ProductToAddDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Raiting { get; set; }
        public string Description { get; set; }
        public bool IsTrending { get; set; }
        public bool IsFeatured { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Color> Color { get; set; }
        public List<Size> Size { get; set; }
    }
}
