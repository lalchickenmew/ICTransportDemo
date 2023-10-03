using ICTransportDemo.DataContract;
using Newtonsoft.Json;
using NuGet.Common;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Xml.Linq;


namespace ICTransportDemo.ServiceAction
{
    public class BusinessLogic
    {
        public string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJpdG1wYmVuekBnbWFpbC5jb20iLCJpZCI6IjEiLCJ1c2VybmFtZSI6ImFkbWluIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ0siLCJleHAiOjE2OTY0MjMwNzgsImlzcyI6IklTRUUiLCJhdWQiOiJodHRwOi8vSVNFRS5jb20ifQ.phY_45WvexCsD9fVW8C52jo9asS1a3M3y5ZtaUfL40o";
        private object client;

        public List<CUSTOMER_DETAIL> CustomerCompamy(string fname)
        {
            RestClient client = new RestClient("http://203.151.136.81/iseecenterapi");
            RestRequest request = new RestRequest($"api/v1/Menus/CounterCall/{fname}", Method.Get);

            request.AddHeader("Authorization", "Bearer " + token);
            var response = client.Execute(request);
            List<CUSTOMER_DETAIL> detail = new List<CUSTOMER_DETAIL>();

            if (response != null)
            {
                if (response.IsSuccessful)
                {
                    detail = JsonConvert.DeserializeObject<List<CUSTOMER_DETAIL>>(response.Content);
                }
            }
            else
            {
                Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
            }
            return detail;
        }

        public  GET_ALL_DETAIL GetDetail(string cus_id , string licen_no)
        {
            RestClient client = new RestClient("http://203.151.136.81/iseecenterapi");
            RestRequest request = new RestRequest($"api/v1/Menus/GetCounterDetail/{cus_id}/{licen_no}", Method.Get);
            request.AddHeader("Authorization", "Bearer " +token);
            var response = client.Execute(request);
            GET_ALL_DETAIL detail = new GET_ALL_DETAIL();
            if (response != null)
            {
                if (response.IsSuccessful)
                {
                    detail = JsonConvert.DeserializeObject<GET_ALL_DETAIL>(response.Content);
                }
            }
            else
            {               
                Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
            }
            return detail;

        }
    }
}
