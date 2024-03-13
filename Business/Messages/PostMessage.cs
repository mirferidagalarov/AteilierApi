using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public static class PostMessage
    {
        internal readonly static string PostNameMinLength = "Name must be minumum 3 symbols";
        internal readonly static string PostNameMaxLength = "Name must be maximum 50 symbols";
        internal readonly static string PostNameNoEmpty = "Name can not be empty";
        internal readonly static string PostNameUnique = "You have size with same name";
        internal readonly static string PostDescriptionMinLength = "Name must be minumum 3 symbols";
        internal readonly static string PostDescriptionMaxLength = "Name must be maximum 500 symbols";
        internal readonly static string PostDescriptionNoEmpty = "Description can not be empty";
        internal readonly static string PostImageNoEmpty = "You must choose post thumbnail";
        public static readonly string PostAddedSuccesfully = "PostAddedSuccesfully";
        public static readonly string PostDeletedSuccesfully = "PostDeletedSuccesfully";
        public static readonly string PostUpdateSuccesfully = "PostUpdateSuccesfully";
    }
}
    