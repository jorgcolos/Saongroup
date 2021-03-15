﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saongroup.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ResultType { get; set; }
        public object Result { get; set; }
    }
}