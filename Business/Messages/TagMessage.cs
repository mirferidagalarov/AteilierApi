using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public static class TagMessage
    {
        internal readonly static string TagNameMinLength = "Name must be minumum 3 symbols";
        internal readonly static string TagNameMaxLength = "Name must be maximum 150 symbols";
        internal readonly static string TagNameNoEmpty = "Name can not be empty";
        internal readonly static string TagNameUnique = "You have size with same name";
        public static readonly string TagAddedSuccesfully = "TagAddedSuccesfully";
        public static readonly string TagDeletedSuccesfully = "TagDeletedSuccesfully";
        public static readonly string TagUpdateSuccesfully = "TagUpdateSuccesfully";
    }
}
