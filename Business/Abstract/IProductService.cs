using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.ProductDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(ProductToAddDTO productToAddDTO);
        IResult Update(ProductToUpdateDTO productToUpdateDTO);
        IResult Delete(int id);
        IDataResult<List<ProductToListDTO>> GetAll();
        IDataResult<ProductToUpdateDTO> Get(int id);    
    }
}
