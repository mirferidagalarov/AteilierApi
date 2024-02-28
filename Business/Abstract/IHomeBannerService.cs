using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.HomeBannerDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHomeBannerService
    {
        IResult Add(HomeBannerAddDTO  homeBannerAddDTO);
        IResult Update(HomeBannerUpdateDTO homeBannerUpdateDTO);
        IResult Delete(int id);  
        IDataResult<List<HomeBannerListDTO>> GetAll();
        IDataResult<HomeBannerUpdateDTO> GetById(int id);
    }
}
