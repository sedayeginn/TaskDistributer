using Microsoft.AspNetCore.Mvc;
using Seda.MVC.UI.Interfaces;
using Seda.MVC.UI.Models;
using System.Diagnostics;

namespace Seda.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly Random _rnd;

        private readonly IAssignmentService _assignmentService;
        public HomeController(IAssignmentService assignmentService)
        {
            _rnd = new Random();
            _assignmentService = assignmentService;
        }

        public IActionResult Index()
        {
            var assignments = _assignmentService.GetAssignments();

            if (assignments.Count == 0)
                for (int i = 1; i < 9; i++)
                {
                    _assignmentService.AddAssignemntAsync(new AssignmentViewModel { Difficulty = _rnd.Next(1, 9), PersonalId = _rnd.Next(1, 500), Name = "Task" + i });
                }

            assignments = _assignmentService.GetAssignments();

            return View(assignments);
        }

        public IActionResult AddRandomAssignment()
        {
            _assignmentService.AddAssignemntAsync(new AssignmentViewModel { Difficulty = _rnd.Next(1, 9), PersonalId = _rnd.Next(1, 500), Name = "Task" + _rnd.Next(1, 90) });
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