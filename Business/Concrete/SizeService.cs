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
    public class SizeService : ISizeService
    {
        private readonly ISizeDAL _sizeDAL;

        public SizeService(ISizeDAL sizeDAL)
        {
            _sizeDAL = sizeDAL;
        }

        public IResult Add(Size size)
        {
            _sizeDAL.Add(size);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Size size)
        {
            _sizeDAL.Update(size);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Size>> GetAll()
        {
          return new SuccessDataResult<List<Size>>(_sizeDAL.GetAll().Where(x=>x.Deleted==Constant.NotDeleted).ToList());
        }

        public IDataResult<Size> GetById(int id)
        {
            return new SuccessDataResult<Size>(_sizeDAL.Get(x => x.ID == id));
        }

        public IResult Update(Size size)
        {
            _sizeDAL.Update(size);
            return  new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        } 
    }
}
