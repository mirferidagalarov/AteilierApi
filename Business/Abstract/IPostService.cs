using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.PostDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        IResult Add(PostToAddDTO  postToAddDTO);
        IResult Update(PostToUpdateDTO  postToUpdateDTO);
        IResult Delete(int id);
        IDataResult<List<PostToListDTO>> GetAll();
        IDataResult<PostToUpdateDTO> GetById(int id);
    }
}
