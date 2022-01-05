﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbToJSON.Application.Contracts
{
    public interface ILoggedInUserService
    {
        public string UserId { get; set; }
        public string UserName { get; set; }    
    }
}
