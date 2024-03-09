using AutoMapper;
using Business.Abstract;
using Business.Validator.Characteristics;
using Business.Validator.Colors;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.CharacteristicDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
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
        private readonly IMapper _mapper;
        public CharacteristicService(ICharacteristicDAL characteristicDAL, IMapper mapper)
        {
            _characteristicDAL = characteristicDAL;
            _mapper = mapper;
        }

        public IResult Add(CharacteristicAddDTO characteristicAddDTO)
        {
            Characteristic characteristic = _mapper.Map<Characteristic>(characteristicAddDTO);
            var validationResult = ValidationTool.Validate(new CharacteristicValidation(), characteristic, out List<ValidationErrorModel> errors);
            if (!validationResult)
              return errors.ValidationErrorMessagesWithNewLine();
            _characteristicDAL.Add(characteristic);
            _characteristicDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(int id)
        {
            var deleteEntity = _characteristicDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();

            deleteEntity.Deleted = id;
            _characteristicDAL.Delete(deleteEntity);
            _characteristicDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<CharacteristicListDTO>> GetAll()
        {
            List<Characteristic> characteristicsList = _characteristicDAL.GetAll(x => x.Deleted == Constant.NotDeleted);
            return new SuccessDataResult<List<CharacteristicListDTO>>(_mapper.Map<List<CharacteristicListDTO>>(characteristicsList));
        }

        public IDataResult<CharacteristicUpdateDTO> GetById(int id)
        {
            Characteristic characteristic=_characteristicDAL.GetById(x=>x.ID==id);
            return new SuccessDataResult<CharacteristicUpdateDTO>(_mapper.Map<CharacteristicUpdateDTO>(characteristic));

        }

        public IResult Update(CharacteristicUpdateDTO characteristicUpdateDTO)
        {
            Characteristic characteristic = _mapper.Map<Characteristic>(characteristicUpdateDTO);
            var validationResult = ValidationTool.Validate(new CharacteristicValidation(), characteristic, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return errors.ValidationErrorMessagesWithNewLine();

            _characteristicDAL.Update(characteristic);
            _characteristicDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
