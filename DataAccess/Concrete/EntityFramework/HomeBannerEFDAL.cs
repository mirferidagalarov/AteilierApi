﻿using Core.DataAccess.Concrete;
using DataAccess.Abstarct;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class HomeBannerEFDAL:RepositoryBase<HomeBanner,AteilerDbContext>,IHomeBannerDAL
    {
        private readonly AteilerDbContext _context;
        public HomeBannerEFDAL(AteilerDbContext context):base(context)
        {
            _context = context; 
        }

    }
}
