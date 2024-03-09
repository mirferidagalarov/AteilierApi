using Core.Helpers.Result.Abstract;
using Entities.Concrete.DTOs.CharacteristicDTOs;
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
        IResult Add(CharacteristicAddDTO  characteristicAddDTO);
        IResult Update(CharacteristicUpdateDTO  characteristicUpdateDTO);
        IResult Delete(int id);
        IDataResult<List<CharacteristicListDTO>> GetAll();
        IDataResult<CharacteristicUpdateDTO> GetById(int id);
    }
}
