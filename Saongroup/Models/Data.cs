using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saongroup.Models
{
    public class Data
    {
        public int Confirmed { get; set; }
        public int Deaths { get; set; }

        public Region Region { get; set; }
    }
}