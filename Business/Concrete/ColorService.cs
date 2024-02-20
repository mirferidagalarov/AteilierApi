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
    public class ColorService : IColorService
    {
        private readonly IColorDAL _colorDAL;
        public ColorService(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }
        public IResult Add(Color color)
        {
         _colorDAL.Add(color);
          return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Color color)
        {
            _colorDAL.Update(color);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll().Where(x=>x.Deleted==Constant.NotDeleted).ToList());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDAL.Get(x=>x.ID==id));
        }

        public IResult Update(Color color)
        {
            _colorDAL.Update(color);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
