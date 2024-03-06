using AutoMapper;
using Entities.Concrete.DTOs.CategoryDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.DTOs.HomeBannerDTOs;
using Entities.Concrete.DTOs.SizeDTOs;
using Entities.Concrete.TableModels;

namespace DataAccess.Mapper
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            #region
            CreateMap<Color, ColorToListDTO>().ReverseMap();
            CreateMap<ColorToAddDTO, Color>().ReverseMap();
            CreateMap<ColorToUpdateDTO, Color>().ReverseMap();
            #endregion


            #region
            CreateMap<HomeBanner, HomeBannerListDTO>().ReverseMap();
            CreateMap<HomeBannerUpdateDTO, HomeBanner>().ReverseMap();
            CreateMap<HomeBannerAddDTO, HomeBanner>().ReverseMap();
            #endregion

            #region
            CreateMap<Size, SizeToListDTO>().ReverseMap();
            CreateMap<SizeToAddDTO,Size>().ReverseMap();
            CreateMap<SizeToUpdateDTO,Size>().ReverseMap();
            #endregion

            #region
            CreateMap<Category, CategoryToListDTO>().ReverseMap();
            CreateMap<CategoryToAddDTO, Category>().ReverseMap();
            CreateMap<CategoryToUpdateDTO, Category>().ReverseMap();
            #endregion
        }
    }
}
