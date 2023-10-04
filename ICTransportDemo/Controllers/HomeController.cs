using ICTransportDemo.DataContract;
using ICTransportDemo.Models;
using ICTransportDemo.ServiceAction;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

namespace ICTransportDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(ViewData["cus_detail"] != null)
            {
                ViewBag.cus_detail = ViewData["cus_detail"];
            }
            
            return View();
        }
       /* public IActionResult Index(string companyname )
        {
            var cus_detail =  ActionName(companyname);
            ViewBag.CompanyName = cus_detail;
            return View();
        }*/

        public IActionResult Search(string companyname)
        {
            BusinessLogic service = new BusinessLogic();
            List<CUSTOMER_DETAIL> cus_detail = service.CustomerCompamy(companyname);
            try
            {
                if (cus_detail.Count() > 1)
                {
                    return PartialView("_Search", cus_detail);
                }
                else
                {
                    ViewData["cus_detail"] = cus_detail;
                    return View("Index",null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            
        }
        public IActionResult ChooseFunction(long id , string name)
        {
            BusinessLogic service = new BusinessLogic();
            List<CUSTOMER_DETAIL> cus_detail =  service.CustomerCompamy(name);
            var vehicle = cus_detail.Where(x => x.customer_id == id);
           
            return View("Index");
        }

        public IActionResult SelectLisen(string cus_id , string lisen)
        {
            VEHICLE_DETAIL vehicle_data = new VEHICLE_DETAIL();
            JOBHEADER job_data = new JOBHEADER();
            CUSTOMER_DETAIL customer = new CUSTOMER_DETAIL();
            BusinessLogic service = new BusinessLogic();
            GET_ALL_DETAIL data = service.GetDetail(cus_id, lisen);
            
            return PartialView("_GetBylisen", data);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}