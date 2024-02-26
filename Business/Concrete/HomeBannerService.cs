using Business.Abstract;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstarct;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HomeBannerService : IHomeBannerService
    {
        private readonly IHomeBannerDAL _homeBannerDAL;
        public HomeBannerService(IHomeBannerDAL homeBannerDAL)
        {
            _homeBannerDAL = homeBannerDAL;
        }

        public IResult Add(HomeBanner homeBanner)
        {
           _homeBannerDAL.Add(homeBanner);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(HomeBanner homeBanner)
        {
            _homeBannerDAL.Update(homeBanner);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<HomeBanner>> GetAll()
        {
           return new SuccessDataResult<List<HomeBanner>>(_homeBannerDAL.GetAll().Where(x=>x.Deleted==Constant.NotDeleted).ToList());
        }

        public IDataResult<HomeBanner> GetById(int id)
        {
            return new SuccessDataResult<HomeBanner>(_homeBannerDAL.GetById(x => x.ID == id));
        }

        public IResult Update(HomeBanner homeBanner)
        {
            _homeBannerDAL.Update(homeBanner);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
