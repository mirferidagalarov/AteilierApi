using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class ProductMessage
    {
        internal readonly static string ProductNameMinLength = "Name must be minimum 3 symbols";
        internal readonly static string ProductNameMaxLength = "Name must be maximum 50 symbols";
        internal readonly static string ProductNameNoEmpty = "Name can not be empty";
        internal readonly static string ProductNameUnique = "You have product with same name";
        internal readonly static string ProductDescriptionNoEmpty = "Description can not be empty";
        internal readonly static string ProductDescriptionMinLength = "Description must be minimum 3 symbols";
        internal readonly static string ProductDescriptionMaxLength = "Description must be maximum 500 symbols";
        internal readonly static string ProductPriceNotEmpty = "You must give price";
        internal readonly static string ProductPriceMinimum = "Price must be minimum 1$";
        internal readonly static string ProductRatingNotEmpty = "You must give rating";
        internal readonly static string ProductRatingMinimum = "Rating must be minimum 1";
        internal readonly static string ProductRatingMaximum = "Rating must be maximum 5";
        internal readonly static string ProductImageNotEmpty = "You must choose product image";
        internal readonly static string ProductCategoryNotEmpty = "You must choose category";
        public static readonly string ProductAddedSuccesfully = "ProductAddedSuccesfully";
        public static readonly string ProductDeletedSuccesfully = "ProductDeletedSuccesfully";
        public static readonly string ProductUpdateSuccesfully = "ProductUpdateSuccesfully";
    }
}
