using Core.DataAccess.Concrete;
using DataAccess.Abstarct;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryEFDAL:RepositoryBase<Category,AteilerDbContext>,ICategoryDAL
    {
        private readonly AteilerDbContext _context;
        public CategoryEFDAL(AteilerDbContext context):base(context)
        {
                _context = context;
        }
    }
}
