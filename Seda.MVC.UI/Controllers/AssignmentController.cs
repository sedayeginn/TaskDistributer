using Microsoft.AspNetCore.Mvc;
using Seda.MVC.UI.Interfaces;
using Seda.MVC.UI.Models;

namespace Seda.MVC.UI.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        
        public IActionResult Index()
        {
            var assignments = _assignmentService.GetAssignments();

            return View(assignments);
        }

        [HttpGet]
        public IActionResult NewAssignment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewAssignment(AssignmentViewModel assignment)
        {
            _assignmentService.AddAssignemntAsync(assignment);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteAssignment(int id)
        {
            _assignmentService.RemoveAssignemntAsync(id);

            return RedirectToAction("Index");
        }

    }
}
