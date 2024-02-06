using Core.DataAccess.Concrete;
using DataAccess.Abstarct;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductEFDal : RepositoryBase<Product, AteilerDbContext>, IProductDAL
    {
        private readonly AteilerDbContext _context;
        public ProductEFDal(AteilerDbContext context) :base(context)
        {
            _context = context;
        }

    }
}
