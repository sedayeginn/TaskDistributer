using Seda.MVC.UI.Models;


namespace Seda.MVC.UI.Interfaces
{
    public interface IAssignmentService
    {
        List<AssignmentViewModel> GetAssignments();

        void AddAssignemntAsync(AssignmentViewModel assignmentViewModel);

        void RemoveAssignemntAsync(int id);

        void SetAllAssignmentAsync();
    }
}
