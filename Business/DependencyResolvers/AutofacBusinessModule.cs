using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;

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

            #region HomeBanner
            builder.RegisterType<HomeBannerEFDAL>().As<IHomeBannerDAL>();   
            builder.RegisterType<HomeBannerService>().As<IHomeBannerService>();
            #endregion

            #region Size
            builder.RegisterType<SizeEFDAL>().As<ISizeDAL>();   
            builder.RegisterType<SizeService>().As<ISizeService>();
            #endregion

            #region Category
            builder.RegisterType<CategoryEFDAL>().As<ICategoryDAL>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            #endregion

            #region Characteristic
            builder.RegisterType<CharacteristicEFDAL>().As<ICharacteristicDAL>();
            builder.RegisterType<CharacteristicService>().As<ICharacteristicService>();
            #endregion

            #region Tag
            builder.RegisterType<TagEFDAL>().As<ITagDAL>();
            builder.RegisterType<TagService>().As<ITagService>();
            #endregion

            #region Post
            builder.RegisterType<PostEFDal>().As<IPostDAL>();   
            builder.RegisterType<PostService>().As<IPostService>(); 
            #endregion

            #region Token
            builder.RegisterType<TokenRepository>().As<ITokenRepository>();
            #endregion
            base.Load(builder);
        }
    }
}
