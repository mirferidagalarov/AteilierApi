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
    public class PostService : IPostService
    {
        private readonly IPostDAL _postDAL;
        public PostService(IPostDAL postDAL)
        {
            _postDAL = postDAL;
        }

        public IResult Add(Post post)
        {
           _postDAL.Add(post);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IResult Delete(Post post)
        {
            _postDAL.Update(post);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postDAL.GetAll().Where(x=>x.Deleted==Constant.NotDeleted).ToList());
        }

        public IDataResult<Post> GetById(int id)
        {
            return new SuccessDataResult<Post>(_postDAL.GetById(x=>x.ID==id));
        }

        public IResult Update(Post post)
        {
            _postDAL.Update(post);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);

        }
    }
}
