using AutoMapper;
using Business.Abstract;
using Business.Validator.Products;
using Core.Extensions;
using Core.Helpers.Constant;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using Core.Validation;
using DataAccess.Abstarct;
using Entities.Concrete.DTOs.ProductDTOs;
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
        private readonly IMapper _mapper;

        public ProductService(IProductDAL productDAL, IMapper mapper)
        {
            _productDAL = productDAL;
            _mapper = mapper;
        }
        public IResult Add(ProductToAddDTO productToAddDTO)
        {
            Product product = _mapper.Map<Product>(productToAddDTO);
            var validationResult = ValidationTool.Validate(new ProductValidation(), product, out List<ValidationErrorModel> errors);
            if (!validationResult)
                return errors.ValidationErrorMessagesWithNewLine();

            _productDAL.Add(product);
            _productDAL.SaveChanges();
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

        public IResult Update(ProductToUpdateDTO productToUpdateDTO)
        {
            Product product = _mapper.Map<Product>(productToUpdateDTO);

            var validateResult = ValidationTool.Validate(new ProductValidation(), product, out List<ValidationErrorModel> errors);
            if (!validateResult)
                return errors.ValidationErrorMessagesWithNewLine();


            _productDAL.Update(product);
            _productDAL.SaveChanges();
            return new SuccessResult(CommonOperationMessage.DataUpdateSuccesfly);
        }
    }
}
