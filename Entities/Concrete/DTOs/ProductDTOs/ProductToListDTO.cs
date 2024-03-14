using Entities.Concrete.DTOs.CharacteristicDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.DTOs.SizeDTOs;
using Entities.Concrete.DTOs.TagDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.ProductDTOs
{
    public class ProductToListDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Raiting { get; set; }
        public string Description { get; set; }
        public bool IsTrending { get; set; }
        public bool IsFeatured { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public List<CharacteristicListDTO> Characteristics { get; set; }
        public List<TagToListDTO> Tags { get; set; }
        public List<ColorToListDTO> Color { get; set; }
        public List<SizeToListDTO> Size { get; set; }
    }
}
