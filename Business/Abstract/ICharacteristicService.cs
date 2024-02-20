using Core.Helpers.Result.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICharacteristicService
    {
        IResult Add(Characteristic characteristic);
        IResult Update(Characteristic characteristic);
        IResult Delete(Characteristic characteristic);
        IDataResult<List<Characteristic>> GetAll();
        IDataResult<Characteristic> GetById(int id);
    }
}
