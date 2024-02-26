﻿using Autofac;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Product
            builder.RegisterType<ProductEFDal>().As<IProductDAL>();
            builder.RegisterType<ProductService>().As<IProductService>();
            #endregion

            #region Color
            builder.RegisterType<ColorEDFAL>().As<IColorDAL>();
            builder.RegisterType<ColorService>().As<IColorService>();
            #endregion

            #region
            //builder.RegisterType<Mapper>().As<IMapper>();
            #endregion

            base.Load(builder);
        }
    }
}