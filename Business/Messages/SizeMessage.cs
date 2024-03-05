using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public static class SizeMessage
    {
        internal readonly static string SizeNameLength = "Name must be maximum 10 symbols";
        internal readonly static string SizeNameNoEmpty = "Name can not be empty";
        public static readonly string SizeAddedSuccesfully = "SizeAddedSuccesfully";
        public static readonly string SizeDeletedSuccesfully = "SizeDeletedSuccesfully";
        public static readonly string SizeUpdateSuccesfully = "SizeUpdateSuccesfully";
    }
}
