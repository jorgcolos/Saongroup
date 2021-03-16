using Newtonsoft.Json;
using RestSharp;
using Saongroup.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Saongroup.Application
{
    public class GetCountries
    {
        public List<Region> ListCountries(string value)
        {
            List<ParamEstructure> param = new List<ParamEstructure>();

            Response countries = HttpGet.JsonRequestGet(param, "regions");

            DataSet data = JsonConvert.DeserializeObject<DataSet>(countries.Result.ToString());

            List<Region> items = new List<Region>();
            if (data != null)
            {
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    items.Add(new Region()
                    {
                        Name = row[1].ToString(),
                        Iso = row[0].ToString()
                    });
                }
            }
            if (value != null)
            {
                items.Where(i => i.Iso == value.ToString());
            };

            return items;
        }
    }
}