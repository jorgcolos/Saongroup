using RestSharp;
using Saongroup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Saongroup.Application
{
    public class HttpGet
    {
        public static Response JsonRequestGet(List<ParamEstructure> parameters, string method, string verb = "GET")
        {
            try
            {
                var client = new RestClient(WebConfigurationManager.AppSettings["urlCovid19"]) { Timeout = 600000 };

                var request = new RestRequest(method, Method.GET);
                request.AddHeader(WebConfigurationManager.AppSettings["Covid19key"], WebConfigurationManager.AppSettings["Covid19Password"]);

                foreach (var values in parameters)
                {
                    request.AddQueryParameter(values.Name, values.Value);
                }


                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                var queryResult = client.Execute(request);

                return new Response
                {
                    IsSuccess = true,
                    Message = queryResult.StatusCode.ToString(),
                    ResultType = queryResult.Content.ToString(),
                    Result = queryResult.Content
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}