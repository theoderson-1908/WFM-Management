using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Diagnostics;
using Wfm.Domain;
using Wfm.Service;
using WfmManagementSystemClient.Models;

namespace WfmManagementSystemClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile user)
        {
            try
            {
                string Uri = string.Format("http://localhost:44586");
                RestRequest request = new RestRequest(Uri);
                var response = client.ExecuteTaskAsync<List<Core.Models.LoginCriteria>>(request);
                if (response.Role == "Manager")
                {
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    return RedirectToAction("Fail", "WfmMember");
                }

            }
            catch
            {
                return View();
            }
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