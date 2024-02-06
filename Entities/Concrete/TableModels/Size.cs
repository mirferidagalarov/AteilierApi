﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Size:BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
