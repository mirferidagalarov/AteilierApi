using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.CategoryDTOs;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(CategoryToAddDTO categoryToAddDTO);
        IResult Update(CategoryToUpdateDTO  categoryToUpdateDTO);
        IResult Delete(int id);
        IDataResult<List<CategoryToListDTO>> GetAll();
        IDataResult<CategoryToUpdateDTO> GetById(int id);
    }
}
