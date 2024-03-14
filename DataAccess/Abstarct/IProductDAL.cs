﻿using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    public interface IProductDAL:IRepository<Product>
    {
      public  List<Product> GetAllWithProduct(Expression<Func<Product,bool>> predicate =null);
    }
}
