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
        public string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJpdG1wYmVuekBnbWFpbC5jb20iLCJpZCI6IjEiLCJ1c2VybmFtZSI6ImFkbWluIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ0siLCJleHAiOjE2OTU5OTM4MDIsImlzcyI6IklTRUUiLCJhdWQiOiJodHRwOi8vSVNFRS5jb20ifQ.Zx_gIZ4WSBcAhAaMUQpl7fulhL1cDWqA-P8LdZK0p10";
        private object client;

        public async Task<List<CUSTOMER_DETAIL>> CustomerCompamy(string fname)
        {
            // RestClient client = new RestClient("http://203.151.136.81/iseecenterapi");
            // RestRequest request = new RestRequest($"api/v1/Menus/CounterCall/{fname}", Method.Get);
            //request.AddParameter("fname", "sssss");
            //  RestResponse response = client.Execute(request);


            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await httpClient.GetAsync($"http://203.151.136.81/iseecenterapi/api/v1/Menus/CounterCall/{fname}");
            List<CUSTOMER_DETAIL> detail = new List<CUSTOMER_DETAIL>();

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response?.Content?.ReadAsStringAsync();
                detail = JsonConvert.DeserializeObject<List<CUSTOMER_DETAIL>>(responseBody);
            }
            else
            {
                detail = new List<CUSTOMER_DETAIL>();
                Console.WriteLine($"HTTP request failed with status code: {response.StatusCode}");
            }

            return detail;
        }

        public  List<GET_ALL_DETAIL> GetDetail(string cus_id , string licen_no)
        {
            RestClient client = new RestClient("http://203.151.136.81/iseecenterapi");
            RestRequest request = new RestRequest($"api/v1/Menus/GetCounterDetail/{cus_id}/{licen_no}", Method.Get);
            request.AddHeader("token", token);
            var response = client.Execute(request);
            List<GET_ALL_DETAIL> detail = new List<GET_ALL_DETAIL>();
            detail = JsonConvert.DeserializeObject<List<GET_ALL_DETAIL>>(response.Content);
            return detail;

        }
    }
}
