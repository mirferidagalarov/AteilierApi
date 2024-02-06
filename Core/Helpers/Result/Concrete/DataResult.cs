﻿using Core.Helpers.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Result.Concrete
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success, List<string> message) : base(success, message)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
