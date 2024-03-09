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
        public static readonly string PostAddedSuccesfully = "PostAddedSuccesfully";
        public static readonly string PostDeletedSuccesfully = "PostDeletedSuccesfully";
        public static readonly string PostUpdateSuccesfully = "PostUpdateSuccesfully";
    }
}
    