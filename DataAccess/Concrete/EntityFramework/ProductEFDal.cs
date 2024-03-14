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

        public List<Product> GetAllWithProduct(Expression<Func<Product, bool>> predicate = null)
        {
            return predicate is null
                ?
                _context.Set<Product>().Include(x => x.Category.Name).Include(x=>x.Color).Include(x=>x.Characteristics).Include(x=>x.Size).Include(x=>x.Color).Include(x=>x.Tags).ToList()
                :
                _context.Set<Product>().Include(x => x.Category.Name).Include(x => x.Color).Include(x => x.Characteristics).Include(x => x.Size).Include(x => x.Color).Include(x => x.Tags).Where(predicate).ToList();
        }

    }
}
