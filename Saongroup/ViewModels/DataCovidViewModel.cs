using Saongroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saongroup.ViewModels
{
    public class DataCovidViewModel
    {
        public Data Data { get; set; }
        public List<DataList.Data> ListData { get; set; }

        public List<Region> Regions { get; set; }


        public IEnumerable<SelectListItem> GetCountriesListItems()
        {
            return Regions.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Iso
            });
        }
    }
}