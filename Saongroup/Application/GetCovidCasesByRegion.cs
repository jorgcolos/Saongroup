using Newtonsoft.Json;
using Saongroup.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Saongroup.Application
{
    public class GetCovidCasesByRegion
    {
        public List<DataList.Data> ListCasesByRegion(string value)
        {
            value = value == null ? "" : value;
            List <ParamEstructure> param = new List<ParamEstructure>();
            DataList data = new DataList();
            param.Add(new ParamEstructure() { Name = "iso", Value = value });

            Response cases = HttpGet.JsonRequestGet(param, "reports");

            data = JsonConvert.DeserializeObject<DataList>(cases.ResultType.ToString());
            List<DataList.Data> SortedList = data.data.OrderByDescending(o => o.confirmed).Take(10).ToList();

            return SortedList;
        }
    }
}