using Core.DataAccess.Concrete;
using DataAccess.Abstarct;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CharacteristicEFDAL :RepositoryBase<Characteristic,AteilerDbContext>,ICharacteristicDAL
    {
        private readonly AteilerDbContext _context;
        public CharacteristicEFDAL(AteilerDbContext context):base(context)
        {
            _context = context;
        }
    }
}
