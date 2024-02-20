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
    public class PostEFDal:RepositoryBase<Post,AteilerDbContext>,IPostDAL
    {
        private readonly AteilerDbContext _context;
        public PostEFDal(AteilerDbContext context):base(context)
        {
            _context = context;
        }
    }
}
