using AutoMapper;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.DTOs.HomeBannerDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
