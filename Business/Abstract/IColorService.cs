using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(ColorToAddDTO colorToAddDTO);
        IResult Update(ColorToUpdateDTO colorToUpdateDTO);
        IResult Delete(int id);
        IDataResult<List<ColorToListDTO>> GetAll(); 
        IDataResult<ColorToUpdateDTO> GetById(int id);
        IDataResult<List<Color>> GetAll(int pageNumber, int pageSize);
    }
}
