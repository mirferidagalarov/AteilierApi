using AutoMapper;
using Business.Abstract;
using Business.Validator.Tags;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.TagDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TagService : ITagService
    {
        private readonly ITagDAL _tagDAL;
        private readonly IMapper _mapper;
        public TagService(ITagDAL tagDAL,IMapper mapper)
        {
            _tagDAL = tagDAL;
            _mapper = mapper;   
        }

        public IResult Add(TagToAddDTO tagToAddDTO)
        {
            Tag tag = _mapper.Map<Tag>(tagToAddDTO);
            var validationResult = ValidationTool.Validate(new TagValidation(), tag, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return errors.ValidationErrorMessagesWithNewLine();

            _tagDAL.Add(tag);
            _tagDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(int id)
        {
            var deleteEntity = _tagDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();

            deleteEntity.Deleted = id;
            _tagDAL.Update(deleteEntity);
            _tagDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<TagToListDTO>> GetAll()
        {
            List<Tag> tagList = _tagDAL.GetAll(x => x.Deleted == Constant.NotDeleted);
           return new SuccessDataResult<List<TagToListDTO>>(_mapper.Map<List<TagToListDTO>>(tagList)); 
        }

        public IDataResult<TagToUpdateDTO> GetById(int id)
        {
            Tag tag = _tagDAL.GetById(x => x.ID == id &&x.Deleted==Constant.NotDeleted);
            return new SuccessDataResult<TagToUpdateDTO>(_mapper.Map<TagToUpdateDTO>(tag));

        }

        public IResult Update(TagToUpdateDTO tagToUpdateDTO)
        {
            Tag tag=_mapper.Map<Tag>(tagToUpdateDTO);
            var validateResult=ValidationTool.Validate(new TagValidation(),tag,out List<ValidationErrorModel> errors);
            if (!validateResult)
                return errors.ValidationErrorMessagesWithNewLine(); 

            _tagDAL.Update(tag);
            _tagDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
