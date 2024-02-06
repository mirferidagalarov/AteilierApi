﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Result.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        List<string> Messages { get; }
    }
}
