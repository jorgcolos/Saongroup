using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saongroup.Models
{
    public class DataList
    {
        public List<Data> data { get; set; }

        public class Region
        {
            public string iso { get; set; }
            public string name { get; set; }
            public string province { get; set; }
            public string lat { get; set; }
            public string @long { get; set; }
            public List<object> cities { get; set; }
        }

        public class Data
        {
            public string date { get; set; }
            public int confirmed { get; set; }
            public int deaths { get; set; }
            public int recovered { get; set; }
            public int confirmed_diff { get; set; }
            public int deaths_diff { get; set; }
            public int recovered_diff { get; set; }
            public string last_update { get; set; }
            public int active { get; set; }
            public int active_diff { get; set; }
            public double fatality_rate { get; set; }
            public Region region { get; set; }
        }
    }
}