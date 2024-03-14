using Entities.Concrete.DTOs.CharacteristicDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.DTOs.SizeDTOs;
using Entities.Concrete.DTOs.TagDTOs;
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
        public List<CharacteristicUpdateDTO> Characteristics { get; set; }
        public List<TagToUpdateDTO> Tags { get; set; }
        public List<ColorToUpdateDTO> Color { get; set; }
        public List<SizeToUpdateDTO> Size { get; set; }
    }
}
