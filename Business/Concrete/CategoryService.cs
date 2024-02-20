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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryService(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public IResult Add(Category category)
        {
            _categoryDAL.Add(category);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Category category)
        {
            _categoryDAL.Update(category);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDAL.GetAll().Where(x => x.Deleted == Constant.NotDeleted).ToList());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDAL.Get(x => x.ID == id));
        }

        public IResult Update(Category category)
        {
            _categoryDAL.Update(category);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
