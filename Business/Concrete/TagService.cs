using Business.Abstract;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstarct;
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
        public TagService(ITagDAL tagDAL)
        {
            _tagDAL = tagDAL;
        }

        public IResult Add(Tag tag)
        {
            _tagDAL.Add(tag);   
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Tag tag)
        {
            _tagDAL.Update(tag);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Tag>> GetAll()
        {
           return new SuccessDataResult<List<Tag>>(_tagDAL.GetAll().Where(x=>x.Deleted==Constant.NotDeleted).ToList()); 
        }

        public IDataResult<Tag> GetById(int id)
        {
            return new SuccessDataResult<Tag>(_tagDAL.GetById(x => x.ID == id));
        }

        public IResult Update(Tag tag)
        {
            _tagDAL.Update(tag);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
