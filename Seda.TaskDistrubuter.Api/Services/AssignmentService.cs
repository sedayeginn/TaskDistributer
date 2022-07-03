using Seda.TaskDistrubuter.Api.DTOS;
using Seda.TaskDistrubuter.Api.Interfaces;
using Seda.TaskDistrubuter.Dal.Entities;
using Seda.TaskDistrubuter.Dal.Repositories;

namespace Seda.TaskDistrubuter.Api.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository<Assignment> _assignmentRepository;

        public AssignmentService(IRepository<Assignment> assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async void AddAssignemntAsync(AssignmentDto assignmentDto)
        {
            Assignment assignment = MapAssignment(assignmentDto);
            _assignmentRepository.AddAsync(assignment);
        }

        public List<AssignmentDto> GetAssignments()
        {
            var assignments = _assignmentRepository.GetAll();
            return MapAssignmentDtos(assignments);
        }

        public void RemoveAssignemntAsync(int id)
        {
            _assignmentRepository.DeleteAsync(id);
        }

        private Assignment MapAssignment(AssignmentDto assignmentDto)
        {
            return new Assignment
            {
                Difficulty = assignmentDto.Difficulty,
                Name = assignmentDto.Name,
                PersonalId = assignmentDto.PersonalId
            };
        }

        private static List<AssignmentDto> MapAssignmentDtos(IEnumerable<Assignment> assignments)
        {
            List<AssignmentDto> assignmentList = new();

            foreach (var assignment in assignments)
            {
                AssignmentDto assignmentDto = new()
                {
                    AssignmentId = assignment.Id,
                    Difficulty = assignment.Difficulty,
                    Name = assignment.Name,
                    PersonalId = assignment.PersonalId
                };

                assignmentList.Add(assignmentDto);
            }

            return assignmentList;
        }

        public void SetAllAssignmentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
