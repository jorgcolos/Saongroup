using Newtonsoft.Json;
using Saongroup.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Saongroup.Application
{
    public class Download
    {
        public string ExportAsXml(string fileName, List<DataList.Data> ListOfEntity)
        {
            try
            {
                var xEle = new XElement("Covid",
                           from data in ListOfEntity
                           select new XElement("TopCovidCases",
                                          new XElement("Country", data.region.name),
                                          new XElement("Province", data.region.province),
                                          new XAttribute("Confirmed", data.confirmed),
                                          new XElement("Deaths", data.deaths)

                                      ));

                xEle.Save(@"C:\" + fileName +".xml");
                return @"C:\" + fileName + ".xml";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string ExportAsJson(string fileName, List<DataList.Data> ListOfEntity)
        {
            try
            {
                var data = JsonConvert.SerializeObject(ListOfEntity);
                File.WriteAllText(@"C:\" + fileName + ".json", data);

                return @"C:\" + fileName + ".json";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string ExportAsCsv<T>(string fileName, List<T> ListOfEntity)
        {
            try
            {

                var lines = new List<string>();
                IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
                var header = string.Join(",", props.ToList().Select(x => x.Name));
                lines.Add(header);
                var valueLines = ListOfEntity.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
                lines.AddRange(valueLines);
                File.WriteAllLines(@"C:\" + fileName + ".csv", lines.ToArray());

                return @"C:\" + fileName + ".csv";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}