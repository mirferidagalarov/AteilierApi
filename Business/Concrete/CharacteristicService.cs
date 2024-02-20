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
    public class CharacteristicService : ICharacteristicService
    {
        private readonly ICharacteristicDAL _characteristicDAL;
        public CharacteristicService(ICharacteristicDAL characteristicDAL)
        {
            _characteristicDAL = characteristicDAL;
        }
        public IResult Add(Characteristic characteristic)
        {
            _characteristicDAL.Add(characteristic); 
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Characteristic characteristic)
        {
            _characteristicDAL.Delete(characteristic);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Characteristic>> GetAll()
        {
            return new SuccessDataResult<List<Characteristic>>(_characteristicDAL.GetAll().Where(x=>x.Deleted==Constant.NotDeleted).ToList());
        }

        public IDataResult<Characteristic> GetById(int id)
        {
            return new SuccessDataResult<Characteristic>(_characteristicDAL.Get(x => x.ID == id));
        }

        public IResult Update(Characteristic characteristic)
        {
            _characteristicDAL.Update(characteristic);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
