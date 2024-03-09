using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.PostDTOs
{
    public class PostToAddDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
