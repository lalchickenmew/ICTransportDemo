using ICTransportDemo.DataContract;
using ICTransportDemo.Models;
using ICTransportDemo.ServiceAction;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            List<CUSTOMER_DETAIL> datafillter = cus_detail.Where(x => x.vehicleCus != null).ToList();
            try
            {
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
/*        public IActionResult ChooseFunction(long id , string name)
        {
            BusinessLogic service = new BusinessLogic();
            List<CUSTOMER_DETAIL> cus_detail =  service.CustomerCompamy(name);
            var vehicle = cus_detail.Where(x => x.customer_id == id);
           
            return View("Index");
        }
*/
        public IActionResult SelectLisen(string cus_id , string lisen)
        {
            BusinessLogic service = new BusinessLogic();
            GET_ALL_DETAIL data = service.GetDetail(cus_id, lisen);

            return PartialView("_GetBylisen", data);
            //return Json(data);
        }
        public IActionResult GetLisenList(string cus_id, string lisen)
        {
            BusinessLogic service = new BusinessLogic();
            GET_ALL_DETAIL data = service.GetDetail(cus_id, lisen);
            //List<VEHICLECUS> listlisen = new List<VEHICLECUS>();
            //listlisen = data.vehicleCus;
            return Json(data.customer.vehicleCus);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}