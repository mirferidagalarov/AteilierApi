using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public static class ColorMessage
    {
        internal readonly static string ColorNameMinLength = "Name must be minumum 3 symbols";
        internal readonly static string ColorNameMaxLength = "Name must be maximum 50 symbols";
        internal readonly static string ColorNameNoEmpty = "Name can not be empty";
        public static readonly string ColorAddedSuccesfully = "ColorAddedSuccesfully";
        public static readonly string ColorDeletedSuccesfully = "ColorDeletedSuccesfully";
        public static readonly string ColorUpdateSuccesfully = "ColorUpdateSuccesfully";

    }
}
