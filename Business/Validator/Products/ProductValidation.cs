using Business.Messages;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Products
{
    public class ProductValidation : AbstractValidator<Product>
    {
        ProductEFDal productEFDAL = new ProductEFDal(new AteilerDbContext(new DbContextOptions<AteilerDbContext>()));

        public ProductValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ProductMessage.ProductNameNoEmpty)
                .MinimumLength(3).WithMessage(ProductMessage.ProductNameMinLength)
                .MaximumLength(50).WithMessage(ProductMessage.ProductNameMaxLength)
                .Must(BeUniqueName).WithMessage(ProductMessage.ProductNameUnique);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ProductMessage.ProductDescriptionNoEmpty)
                .MinimumLength(3).WithMessage(ProductMessage.ProductDescriptionMinLength)
                .MaximumLength(500).WithMessage(ProductMessage.ProductDescriptionMaxLength);
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(ProductMessage.ProductPriceNotEmpty)
                .GreaterThan(1).WithMessage(ProductMessage.ProductPriceMinimum);
            RuleFor(x => x.Raiting)
                .NotEmpty().WithMessage(ProductMessage.ProductRatingNotEmpty)
                .GreaterThanOrEqualTo(1).WithMessage(ProductMessage.ProductRatingMinimum)
                .LessThanOrEqualTo(5).WithMessage(ProductMessage.ProductRatingMaximum);
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage(ProductMessage.ProductImageNotEmpty);
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage(ProductMessage.ProductCategoryNotEmpty);
        }
        private bool BeUniqueName(string name)
        {
            return !productEFDAL.GetAll(p => p.Name == name && p.Deleted == 0).Any();
        }
    }
}
