using AutoMapper;
using Business.Abstract;
using Business.Validator.Posts;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.PostDTOs;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostDAL _postDAL;
        private readonly IMapper _mapper;
        public PostService(IPostDAL postDAL,IMapper mapper)
        {
            _postDAL = postDAL;
            _mapper = mapper;   
        }

        public IResult Add(PostToAddDTO postToAddDTO)
        {
            Post post=_mapper.Map<Post>(postToAddDTO);
            var validationResult = ValidationTool.Validate(new PostValidation(), post, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return errors.ValidationErrorMessagesWithNewLine();

           _postDAL.Add(post);
            _postDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IResult Delete(int id)
        {
            var deleteEntity = _postDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();

            deleteEntity.Deleted = id;

            _postDAL.Update(deleteEntity);
            _postDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<PostToListDTO>> GetAll()
        {
           List<Post> posts=_postDAL.GetAll(x=>x.Deleted==Constant.NotDeleted);
            return new SuccessDataResult<List<PostToListDTO>>(_mapper.Map<List<PostToListDTO>>(posts));
        }

        public IDataResult<PostToUpdateDTO> GetById(int id)
        {
            Post post = _postDAL.GetById(x => x.ID == id && x.Deleted == Constant.NotDeleted);
            return new SuccessDataResult<PostToUpdateDTO>(_mapper.Map<PostToUpdateDTO>(post));
        }

        public IResult Update(PostToUpdateDTO postToUpdateDTO)
        {
            Post post=_mapper.Map<Post>(postToUpdateDTO);   

            var validateResult=ValidationTool.Validate(new PostValidation(),post,out List<ValidationErrorModel> errors);
            if (!validateResult)
                return errors.ValidationErrorMessagesWithNewLine();


            _postDAL.Update(post);
            _postDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);

        }
    }
}
