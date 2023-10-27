using ICTransportDemo.DataContract;
using ICTransportDemo.Models;
using ICTransportDemo.ServiceAction;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ICTransportDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private string _token = string.Empty;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
           // _token = token;
        }
        //รับ token username จาก menu กลาง
        public IActionResult Index(string token)
        {
            HttpContext.Session.SetString("Token", token);
            //HttpContext.Session.SetString("", "Token");
            if (ViewData["cus_detail"] != null)
            {
                ViewBag.cus_detail = ViewData["cus_detail"];
            }

            return View();
        }
        public IActionResult Search(string companyname)
        {
            string token = HttpContext.Session.GetString("Token");

            BusinessLogic service = new BusinessLogic(_configuration , HttpContext.Session.GetString("Token"));
            List<CUSTOMER_DETAIL> cus_detail = service.CustomerCompamy(companyname);
            List<CUSTOMER_DETAIL> datafillter = cus_detail.Where(x => x.vehicleCus != null).ToList();
            try
            {
                //string token = HttpContext.Session.GetString("Token");
                //if (string.IsNullOrEmpty(token))
                //{
                //    throw new Exception("token null");
                //}
                if (cus_detail.Count() > 1)
                {
                    return PartialView("_Search", datafillter);
                }
                else
                {
                    return Json(cus_detail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public IActionResult SelectLisen(string cus_id, string lisen)
        {
            BusinessLogic service = new BusinessLogic(_configuration, HttpContext.Session.GetString("Token"));
            GET_ALL_DETAIL data = service.GetDetail(cus_id, lisen);

            return PartialView("_GetBylisen", data);
            //return Json(data);
        }
        public IActionResult GetLisenList(string cus_id, string lisen)
        {
            BusinessLogic service = new BusinessLogic(_configuration, HttpContext.Session.GetString("Token"));
            GET_ALL_DETAIL data = service.GetDetail(cus_id, lisen);
            //List<VEHICLECUS> listlisen = new List<VEHICLECUS>();
            //listlisen = data.vehicleCus;
            return Json(data.customer.vehicleCus);
        }
        [HttpPost]
        public IActionResult JobDetail(List<JOBHEADER> myList)
        {
            //var a = JsonConvert.DeserializeObject<JOBHEADER>(jobdetail);
            return PartialView( "_JobDetail",myList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}