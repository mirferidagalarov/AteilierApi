using Core.Helpers.Result.Abstract;
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
        IResult Add(HomeBanner homeBanner);
        IResult Update(HomeBanner homeBanner);
        IResult Delete(HomeBanner homeBanner);  
        IDataResult<List<HomeBanner>> GetAll();
        IDataResult<HomeBanner> GetById(int id);
    }
}
