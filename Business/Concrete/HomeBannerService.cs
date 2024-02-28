using AutoMapper;
using Business.Abstract;
using Business.Validator.Colors;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.DTOs.HomeBannerDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HomeBannerService : IHomeBannerService
    {
        private readonly IHomeBannerDAL _homeBannerDAL;
        private readonly IMapper _mapper;
        public HomeBannerService(IHomeBannerDAL homeBannerDAL,IMapper mapper)
        {
            _homeBannerDAL = homeBannerDAL;
            _mapper = mapper;
        }

        public IResult Add(HomeBannerAddDTO homeBannerAddDTO)
        {
            HomeBanner homeBanner = _mapper.Map<HomeBanner>(homeBannerAddDTO);
            _homeBannerDAL.Add(homeBanner);
            _homeBannerDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(int id)
        {
            var deleteEntity = _homeBannerDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();


            deleteEntity.Deleted = id;
            _homeBannerDAL.Update(deleteEntity);
            _homeBannerDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<HomeBannerListDTO>> GetAll()
        {
            List<HomeBanner> homeBanners = _homeBannerDAL.GetAll(x => x.Deleted == Constant.NotDeleted);
            return new SuccessDataResult<List<HomeBannerListDTO>>(_mapper.Map<List<HomeBannerListDTO>>(homeBanners));
        }

        public IDataResult<HomeBannerUpdateDTO> GetById(int id)
        {
            HomeBanner homeBanner  = _homeBannerDAL.GetById(x => x.ID == id);
            return new SuccessDataResult<HomeBannerUpdateDTO>(_mapper.Map<HomeBannerUpdateDTO>(homeBanner));
        }

        public IResult Update(HomeBannerUpdateDTO homeBannerUpdateDTO)
        {
            HomeBanner homeBanner = _mapper.Map<HomeBanner>(homeBannerUpdateDTO);
            _homeBannerDAL.Update(homeBanner);
            _homeBannerDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
