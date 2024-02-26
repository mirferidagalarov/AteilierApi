using Business.Abstract;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstarct;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization.Policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productDAL;
        public ProductService(IProductDAL productDAL)
        {
                _productDAL = productDAL;
        }
        public IResult Add(Product product)
        {
           _productDAL.Add(product);
            return new SuccessResult(CommonOperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(int id)
        {
            var deleteEntity = _productDAL.GetById(x => x.ID == id);
            if (deleteEntity is null)
                return new ErrorResult();

            deleteEntity.Deleted = id;
            _productDAL.Update(deleteEntity);
            return new SuccessResult(CommonOperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<Product> Get(int id)
        {
            return new SuccessDataResult<Product>(_productDAL.GetById(x => x.ID == id));
        }

        public IDataResult<List<Product>> GetAll()
        {
           return new SuccessDataResult<List<Product>>(_productDAL.GetAll().Where(x=>x.Deleted ==Constant.NotDeleted).ToList());
        }

        public IResult Update(Product product)
        {
            _productDAL.Update(product);
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
