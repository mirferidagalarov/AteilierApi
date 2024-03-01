using AutoMapper;
using Business.Abstract;
using Business.Validator.Categories;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.CategoryDTOs;
using Entities.Concrete.DTOs.ColorDTOs;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryDAL categoryDAL,IMapper mapper)
        {
            _categoryDAL = categoryDAL;
            _mapper = mapper;
        }

        public IResult Add(CategoryToAddDTO categoryToAddDTO)
        {
            Category category = _mapper.Map<Category>(categoryToAddDTO);
            var validationResult = ValidationTool.Validate(new CategoryValidation(), category, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            _categoryDAL.Add(category);
            _categoryDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(int id)
        {
            var deleteEntity = _categoryDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();

            deleteEntity.Deleted = id;
            _categoryDAL.Update(deleteEntity);
            _categoryDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<CategoryToListDTO>> GetAll()
        {
            List<Category> categories = _categoryDAL.GetAll(x => x.Deleted == Constant.NotDeleted);
            return new SuccessDataResult<List<CategoryToListDTO>>(_mapper.Map<List<CategoryToListDTO>>(categories));
        }

        public IDataResult<CategoryToUpdateDTO> GetById(int id)
        {
            Category category = _categoryDAL.GetById(x => x.ID == id);
            return new SuccessDataResult<CategoryToUpdateDTO>(_mapper.Map<CategoryToUpdateDTO>(category));
        }

        public IResult Update(CategoryToUpdateDTO categoryToUpdateDTO)
        {
            Category category = _mapper.Map<Category>(categoryToUpdateDTO);
            var validationResult = ValidationTool.Validate(new CategoryValidation(), category, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());

            _categoryDAL.Update(category);
            _categoryDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }
    }
}
