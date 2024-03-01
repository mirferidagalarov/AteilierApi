using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public static class CategoryMessage
    {
        internal readonly static string CategoryNameMinLength = "Name must be minumum 3 symbols";
        internal readonly static string CategoryNameMaxLength = "Name must be maximum 50 symbols";
        internal readonly static string CategoryNameNoEmpty = "Name can not be empty";
        public static readonly string CategoryAddedSuccesfully = "CategoryAddedSuccesfully";
        public static readonly string CategoryDeletedSuccesfully = "CategoryDeletedSuccesfully";
        public static readonly string CategoryUpdateSuccesfully = "CategoryUpdateSuccesfully";
    }
}
