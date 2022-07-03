using Seda.MVC.UI.Interfaces;
using Seda.MVC.UI.Models;
using Seda.TaskDistrubuter.Dal;
using Seda.TaskDistrubuter.Dal.Entities;
using Seda.TaskDistrubuter.Dal.Repositories;

namespace Seda.MVC.UI.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository<Assignment> _assignmentRepository;

        public AssignmentService(IRepository<Assignment> assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async void AddAssignemntAsync(AssignmentViewModel assignmentViewModel)
        {
            Assignment assignment = MapAssignment(assignmentViewModel);
            _assignmentRepository.AddAsync(assignment);
        }

        public List<AssignmentViewModel> GetAssignments()
        {
            SampleData sampleData = new SampleData();

            //sampleData.CreateTestDataAsync();

            var assignments = _assignmentRepository.GetAll();
            return MapAssignmentViewModels(assignments);
        }

        public void RemoveAssignemntAsync(int id)
        {
            _assignmentRepository.DeleteAsync(id);
        }

        private Assignment MapAssignment(AssignmentViewModel assignmentViewModel)
        {
            return new Assignment
            {
                Difficulty = assignmentViewModel.Difficulty,
                Name = assignmentViewModel.Name,
                PersonalId = assignmentViewModel.PersonalId
            };
        }

        private static List<AssignmentViewModel> MapAssignmentViewModels(IEnumerable<Assignment> assignments)
        {
            List<AssignmentViewModel> assignmentList = new();

            foreach (var assignment in assignments)
            {
                AssignmentViewModel assignmentViewModel = new()
                {
                    AssignmentId = assignment.Id,
                    Difficulty = assignment.Difficulty,
                    Name = assignment.Name,
                    PersonalId = assignment.PersonalId
                };

                assignmentList.Add(assignmentViewModel);
            }

            return assignmentList;
        }

        public void SetAllAssignmentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
