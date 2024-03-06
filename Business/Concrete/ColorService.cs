using AutoMapper;
using Business.Abstract;
using Business.Validator.Categories;
using Business.Validator.Colors;
using Business.Validator.Sizes;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorService : IColorService
    {
        private readonly IColorDAL _colorDAL;
        private readonly IMapper _mapper;
        public ColorService(IColorDAL colorDAL,IMapper mapper)
        {
            _colorDAL = colorDAL;
            _mapper = mapper;
        }
        public IResult Add(ColorToAddDTO  colorToAddDTO)
        {
            Color color=_mapper.Map<Color>(colorToAddDTO);
            var validationResult = ValidationTool.Validate(new ColorValidation(), color, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return errors.ValidationErrorMessagesWithNewLine();

            _colorDAL.Add(color);
            _colorDAL.SaveChanges();
          return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(int id)
        {
            var deleteEntity = _colorDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();


            deleteEntity.Deleted = id;
            _colorDAL.Update(deleteEntity);
            _colorDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<ColorToListDTO>> GetAll()
        {
            List<Color> colorList=_colorDAL.GetAll(x=>x.Deleted==Constant.NotDeleted);
            return new SuccessDataResult<List<ColorToListDTO>>(_mapper.Map<List<ColorToListDTO>>(colorList));

        }

        public IDataResult<List<Color>> GetAll(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll(pageNumber, pageSize, filter: x => x.Deleted == Constant.NotDeleted));
        }

        public IDataResult<ColorToUpdateDTO> GetById(int id)
        {
            Color color = _colorDAL.GetById(x=>x.ID==id);
            return new SuccessDataResult<ColorToUpdateDTO>(_mapper.Map<ColorToUpdateDTO>(color));
        }

        public IResult Update(ColorToUpdateDTO colorToUpdateDTO)
        {
            Color color = _mapper.Map<Color>(colorToUpdateDTO);
            var validationResult = ValidationTool.Validate(new ColorValidation(), color, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return errors.ValidationErrorMessagesWithNewLine();

            _colorDAL.Update(color);
            _colorDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
