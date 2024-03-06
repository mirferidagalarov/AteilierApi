﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.DTOs.Auth
{
    public class LoginRequestDTO
    {
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
