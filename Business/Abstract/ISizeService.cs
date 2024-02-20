using Core.Helpers.Result.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISizeService
    {
        IResult Add(Size size);
        IResult Update(Size size);
        IResult Delete(Size size);  
        IDataResult<List<Size>> GetAll();
        IDataResult<Size> GetById(int id);  
    }
}
