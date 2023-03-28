using MediatR;
using PX.Approval.Domain.Response;


namespace PX.Approval.Application.GoalsPlanning.Queries
{
    public class GetAllValuedCPBrandByGoalsPlanningQuery : IRequest<Response>
    {
        public Guid GoalsPlanningId { get; set; }

    }
}
