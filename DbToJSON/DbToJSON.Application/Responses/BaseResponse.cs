﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbToJSON.Application.Responses
{
    public class BaseResponse
    {
        public bool? Success { get; set; }

        public BaseResponse()
        {
            
        }
    }
}
