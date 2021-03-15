using Newtonsoft.Json;
using Saongroup.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Saongroup.Application
{
    public class GetCovidCases
    {
        public List<DataList.Data> ListCases()
        {
            List<ParamEstructure> param = new List<ParamEstructure>();
            DataList data = new DataList();
            Response cases = HttpGet.JsonRequestGet(param, "reports");
            List<DataList.Data> sortedList = new List<DataList.Data>();

            data = JsonConvert.DeserializeObject<DataList>(cases.ResultType.ToString());
            if(data != null)
                sortedList = data.data.OrderByDescending(o => o.confirmed).Take(10).ToList();

            return sortedList;
        }
    }
}