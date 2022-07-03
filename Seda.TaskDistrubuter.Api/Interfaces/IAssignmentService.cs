using Seda.TaskDistrubuter.Api.DTOS;

namespace Seda.TaskDistrubuter.Api.Interfaces
{
    public interface IAssignmentService
    {
        List<AssignmentDto> GetAssignments();

        void AddAssignemntAsync(AssignmentDto assignmentDto);

        void RemoveAssignemntAsync(int id);

        void SetAllAssignmentAsync();
    }
}
