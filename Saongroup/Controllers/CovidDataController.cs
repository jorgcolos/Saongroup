using Saongroup.Application;
using Saongroup.Models;
using Saongroup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saongroup.Controllers
{
    public class CovidDataController : Controller
    {

        public ActionResult CovidData()
        {
            DataCovidViewModel model = new DataCovidViewModel();
            GetCountries countries = new GetCountries();
            GetCovidCases cases = new GetCovidCases();

            List<DataList.Data> data = cases.ListCases();

            model.Regions = countries.ListCountries("");
            model.ListData = data;
            return View(model);
        }

        [HttpPost]
        public ActionResult CovidData(string value)
        {
            value = Request.Form["Countries"];
            GetCountries countries = new GetCountries();
            GetCovidCasesByRegion casesByRegion = new GetCovidCasesByRegion();

            List<Region> items = countries.ListCountries(value);

            List<DataList.Data> data = casesByRegion.ListCasesByRegion(value);
            ViewBag.Countries = items;

            if (Request.Form["Countries"] != null)
            {
                items.Where(i => i.Iso == value.ToString());
            };

            ViewData["selectedCountry"] = Request.Form["Countries"];

            var viewModel = new DataCovidViewModel
            {
                Regions = items,
                ListData = data
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Export(string value)
        {
            DataCovidViewModel model = new DataCovidViewModel();
            GetCovidCases cases = new GetCovidCases();
            GetCovidCasesByRegion casesByRegion = new GetCovidCasesByRegion();

            value = Request.Form["Countries"];
            var ExportTo = Request.Form["Export"];

            List<DataList.Data> data = new List<DataList.Data>();
            if (value == null)
                data = cases.ListCases();
            else
                data = casesByRegion.ListCasesByRegion(value);

            try
            {
                var export = "";
                Download download = new Download();

                switch (ExportTo)
                {
                    case ("XML"):
                        export = download.ExportAsXml("CovidCases" + DateTime.Now.Millisecond, data);
                        break;
                    case ("JSON"):
                        export = download.ExportAsJson("CovidCases" + DateTime.Now.Millisecond, data);
                        break;
                    case ("CSV"):
                        export = download.ExportAsCsv("CovidCases" + DateTime.Now.Millisecond, data);
                        break;
                    default:
                        break;
                }
                ViewData["FileTransfer"] = export;

                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
