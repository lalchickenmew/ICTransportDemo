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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ActionName(string companyname)
        {
            BusinessLogic service = new BusinessLogic();
            try
            {
                //CUSTOMER_DETAIL cus_detail = service.CustomerCompamy(companyname);
                List<CUSTOMER_DETAIL> cus_detail = await service.CustomerCompamy(companyname);
                ViewBag.CompanyName = cus_detail;
            }
            catch (Exception ex)
            {
                
            }
            return View("Index");
        }
        public IActionResult MyPartialAction(string id , string name)
        {
            // Perform any necessary logic
            // Return the partial view
            BusinessLogic service = new BusinessLogic();
            var a = service.GetDetail(id, name);
            ViewBag.Name = id;
            ViewBag.Licen = name; 
            ViewBag.ShowModal = false;
            return View("Index");
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