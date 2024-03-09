using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.TagDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITagService
    {
        IResult Add(TagToAddDTO tagToAddDTO);
        IResult Update(TagToUpdateDTO tagToUpdateDTO);
        IResult Delete(int id);
        IDataResult<List<TagToListDTO>> GetAll();
        IDataResult<TagToUpdateDTO> GetById(int id);
    }
}
