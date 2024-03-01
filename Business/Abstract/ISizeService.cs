using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.SizeDTOs;
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
        IResult Add(SizeToAddDTO sizeToAddDTO);
        IResult Update(SizeToUpdateDTO sizeToUpdateDTO);
        IResult Delete(int id);  
        IDataResult<List<SizeToListDTO>> GetAll();
        IDataResult<SizeToUpdateDTO> GetById(int id);  
    }
}
