using AutoMapper;
using Entities.Concrete.DTOs.CategoryDTOs;
using Entities.Concrete.DTOs.CharacteristicDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.DTOs.HomeBannerDTOs;
using Entities.Concrete.DTOs.PostDTOs;
using Entities.Concrete.DTOs.SizeDTOs;
using Entities.Concrete.DTOs.TagDTOs;
using Entities.Concrete.TableModels;

namespace DataAccess.Mapper
{
    public class Automapper: Profile
    {
        public Automapper()
        {
            #region Color
            CreateMap<Color, ColorToListDTO>().ReverseMap();
            CreateMap<ColorToAddDTO, Color>().ReverseMap();
            CreateMap<ColorToUpdateDTO, Color>().ReverseMap();
            #endregion

            #region HomeBanner
            CreateMap<HomeBanner, HomeBannerListDTO>().ReverseMap();
            CreateMap<HomeBannerUpdateDTO, HomeBanner>().ReverseMap();
            CreateMap<HomeBannerAddDTO, HomeBanner>().ReverseMap();
            #endregion

            #region Size
            CreateMap<Size, SizeToListDTO>().ReverseMap();
            CreateMap<SizeToAddDTO,Size>().ReverseMap();
            CreateMap<SizeToUpdateDTO,Size>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, CategoryToListDTO>().ReverseMap();
            CreateMap<CategoryToAddDTO, Category>().ReverseMap();
            CreateMap<CategoryToUpdateDTO, Category>().ReverseMap();
            #endregion

            #region Characteristic
            CreateMap<Characteristic, CharacteristicListDTO>().ReverseMap();
            CreateMap<CharacteristicAddDTO, Characteristic>().ReverseMap();
            CreateMap<CharacteristicUpdateDTO, Characteristic>().ReverseMap();
            #endregion

            #region Tag

            CreateMap<Tag, TagToListDTO>().ReverseMap();
            CreateMap<TagToUpdateDTO, Tag>().ReverseMap();
            CreateMap<TagToAddDTO, Tag>().ReverseMap();
            #endregion

            #region Post
            CreateMap<Post, PostToListDTO>().ReverseMap();
            CreateMap<PostToUpdateDTO, Post>().ReverseMap();
            CreateMap<PostToAddDTO, Post>().ReverseMap();
            #endregion
        }
    }
}
