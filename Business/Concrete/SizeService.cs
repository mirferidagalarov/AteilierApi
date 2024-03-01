using AutoMapper;
using Business.Abstract;
using Business.Validator.Colors;
using Business.Validator.Sizes;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.DTOs.SizeDTOs;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class SizeService : ISizeService
    {
        private readonly ISizeDAL _sizeDAL;
        private readonly IMapper _mapper;

        public SizeService(ISizeDAL sizeDAL,IMapper mapper)
        {
            _sizeDAL = sizeDAL;
            _mapper = mapper;   
        }

        public IResult Add(SizeToAddDTO sizeToAddDTO)
        {
            Size size = _mapper.Map<Size>(sizeToAddDTO);

            var validationResult = ValidationTool.Validate(new SizeValidation(), size, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            _sizeDAL.Add(size);
            _sizeDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);

        }

        public IResult Delete(int id)
        {
            var deleteEntity = _sizeDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();

            deleteEntity.Deleted = id;
            _sizeDAL.Update(deleteEntity);
            _sizeDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<SizeToListDTO>> GetAll()
        {
            List<Size> sizeList = _sizeDAL.GetAll(x => x.Deleted == Constant.NotDeleted);
            return new SuccessDataResult<List<SizeToListDTO>>(_mapper.Map<List<SizeToListDTO>>(sizeList));
        }

        public IDataResult<SizeToUpdateDTO> GetById(int id)
        {
            Size size = _sizeDAL.GetById(x => x.ID == id);
            return new SuccessDataResult<SizeToUpdateDTO>(_mapper.Map<SizeToUpdateDTO>(size));
        }

        public IResult Update(SizeToUpdateDTO sizeToUpdateDTO)
        {
            Size size = _mapper.Map<Size>(sizeToUpdateDTO);
            var validationResult = ValidationTool.Validate(new SizeValidation(), size, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            _sizeDAL.Update(size);
            _sizeDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
