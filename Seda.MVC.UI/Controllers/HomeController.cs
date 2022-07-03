using Microsoft.AspNetCore.Mvc;
using Seda.MVC.UI.Interfaces;
using Seda.MVC.UI.Models;
using System.Diagnostics;

namespace Seda.MVC.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IAssignmentService _assignmentService;
        public HomeController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        public IActionResult Index()
        {

            var assignments = _assignmentService.GetAssignments();

            return View(assignments);
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