using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class HomeBanner:BaseEntity, IEntity
    {
        public string ImagePath { get; set; }
    }
}
