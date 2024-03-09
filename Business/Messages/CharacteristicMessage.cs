using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Messages
{
    public class CharacteristicMessage
    {
        internal readonly static string CharacteristicNameMinLength = "Name must be minumum 3 symbols";
        internal readonly static string CharacteristicNameMaxLength = "Name must be maximum 50 symbols";
        internal readonly static string CharacteristicNameNoEmpty = "Name can not be empty";
        public static readonly string CharacteristicAddedSuccesfully = "CharacteristicAddedSuccesfully";
        public static readonly string CharacteristicDeletedSuccesfully = "CharacteristicDeletedSuccesfully";
        public static readonly string CharacteristicUpdateSuccesfully = "CharacteristicUpdateSuccesfully";
    }
}
